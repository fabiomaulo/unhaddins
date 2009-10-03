using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Castle.Core.Interceptor;

namespace uNhAddIns.ComponentBehaviors.Castle
{
	public class NotifyPropertyChangedBehavior : IInterceptor, IBehavior
	{
		PropertyChangedEventHandler _handler;

		#region IBehavior Members

		/// <summary>
		/// Additional interfaces for the proxy.
		/// </summary>
		/// <returns></returns>
		public Type[] GetAdditionalInterfaces()
		{
			return new[] {typeof (INotifyPropertyChanged)};
		}

		/// <summary>
		/// Relative order as interceptor.
		/// </summary>
		/// <returns></returns>
		public int GetRelativeOrder()
		{
			return 1;
		}

		#endregion

		#region IInterceptor Members

		public void Intercept(IInvocation invocation)
		{
			string methodName = invocation.Method.Name;
			object[] arguments = invocation.Arguments;
			object proxy = invocation.Proxy;
			bool isEditableObject = proxy is IEditableObject;

			if (invocation.MethodInvocationTarget.DeclaringType.Equals(typeof (INotifyPropertyChanged)))
			{
				if (methodName == "add_PropertyChanged")
				{
					StoreHandler((Delegate) arguments[0]);
				}
				if (methodName == "remove_PropertyChanged")
				{
					RemoveHandler((Delegate) arguments[0]);
				}
			}


			if (!ShouldProceedWithInvocation(methodName))
				return;

			invocation.Proceed();

			NotifyPropertyChanged(methodName, proxy, isEditableObject);
		}

		#endregion

		protected void OnPropertyChanged(Object sender, PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler eventHandler = _handler;
			if (eventHandler != null) eventHandler(sender, e);
		}

		protected void RemoveHandler(Delegate @delegate)
		{
			_handler = (PropertyChangedEventHandler) Delegate.Remove(_handler, @delegate);
		}

		protected void StoreHandler(Delegate @delegate)
		{
			_handler = (PropertyChangedEventHandler) Delegate.Combine(_handler, @delegate);
		}

		protected void NotifyPropertyChanged(string methodName, object proxy, bool isEditableObject)
		{
			if ("CancelEdit".Equals(methodName) && isEditableObject)
			{
				foreach (PropertyInfo prop in proxy.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite))
				{
					OnPropertyChanged(proxy, new PropertyChangedEventArgs(prop.Name));
				}
			}

			if (methodName.StartsWith("set_"))
			{
				string propertyName = methodName.Substring(4);

				var args = new PropertyChangedEventArgs(propertyName);
				OnPropertyChanged(proxy, args);
			}
		}

		protected bool ShouldProceedWithInvocation(string methodName)
		{
			var methodsWithoutTarget = new[] {"add_PropertyChanged", "remove_PropertyChanged"};
			if (methodsWithoutTarget.Contains(methodName))
				return false;
			return true;
		}
	}
}