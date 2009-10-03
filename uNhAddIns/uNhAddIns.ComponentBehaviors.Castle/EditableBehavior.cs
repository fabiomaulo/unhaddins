using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Castle.Core.Interceptor;

namespace uNhAddIns.ComponentBehaviors.Castle
{
	public class EditableBehavior : IInterceptor, IBehavior
	{
		readonly IDictionary<PropertyInfo, object> _tempValues
			= new Dictionary<PropertyInfo, object>();

		bool _isInEditMode;
		Dictionary<string, PropertyInfo> _properties;

		public virtual bool IsEditing
		{
			get { return _isInEditMode; }
		}

		#region IBehavior Members

		/// <summary>
		/// Additional interfaces for the proxy.
		/// </summary>
		/// <returns></returns>
		public Type[] GetAdditionalInterfaces()
		{
			return new[] {typeof (IEditableObject)};
		}

		/// <summary>
		/// Relative order as interceptor.
		/// </summary>
		/// <returns></returns>
		public int GetRelativeOrder()
		{
			return 0;
		}

		#endregion

		#region IInterceptor Members

		public void Intercept(IInvocation invocation)
		{
			switch (invocation.Method.Name)
			{
				case "BeginEdit":
					BeginEdit();
					return;
				case "CancelEdit":
					CancelEdit();
					return;
				case "EndEdit":
					EndEdit(invocation.InvocationTarget);
					return;
				default:
					break;
			}

			if ((!invocation.Method.Name.StartsWith("get_") &&
			     !invocation.Method.Name.StartsWith("set_")) || !IsEditing)
			{
				invocation.Proceed();
				return;
			}

			if (_properties == null)
			{
				IEnumerable<PropertyInfo> propertyInfos = invocation.InvocationTarget.GetType().GetProperties(BindingFlags.Public |
				                                                                                              BindingFlags.Instance)
					.Where(p => p.CanWrite);
				//TODO: Enhance this.
				_properties = new Dictionary<string, PropertyInfo>();
				foreach (PropertyInfo propertyInfo in propertyInfos)
				{
					if (!_properties.ContainsKey(propertyInfo.Name))
						_properties[propertyInfo.Name] = propertyInfo;
				}
			}

			bool isSet = invocation.Method.Name.StartsWith("set_");
			string propertyName = invocation.Method.Name.Substring(4);
			PropertyInfo property;
			if (!_properties.TryGetValue(propertyName, out property))
			{
				invocation.Proceed();
				return;
			}

			if (isSet)
			{
				_tempValues[property] = invocation.Arguments[0];
			}
			else
			{
				invocation.Proceed();
				object value;
				if (_tempValues.TryGetValue(property, out value))
					invocation.ReturnValue = value;
			}
		}

		#endregion

		public void BeginEdit()
		{
			_isInEditMode = true;
		}

		public void CancelEdit()
		{
			_tempValues.Clear();
			_isInEditMode = false;
		}

		public void EndEdit(object target)
		{
			_isInEditMode = false;
			foreach (PropertyInfo property in _tempValues.Keys)
			{
				property.SetValue(target, _tempValues[property], null);
			}
		}
	}
}