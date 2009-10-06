using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using uNhAddIns.Adapters;
using System.ComponentModel.DataAnnotations;

namespace uNhAddIns.DataAnnotations
{
	public class EntityValidator : IEntityValidator
	{

		#region IEntityValidator Members

		///<summary>
		/// Returns true if the entity is valid.
		///</summary>
		///<param name="entityInstance"></param>
		///<returns></returns>
		public bool IsValid(object entityInstance)
		{
			var validators = from property in entityInstance.GetType().GetProperties()
			                 from attribute in property.GetCustomAttributes(typeof (ValidationAttribute), true)
												.OfType<ValidationAttribute>()
			                  select new {
											Validator = attribute, 
											ValueToValidate =	property.GetValue(entityInstance, null)
										 };

			return validators.Any(validation => validation.Validator.IsValid(validation.ValueToValidate));
		}

		///<summary>
		/// Validates an entity and returns the information about invalid values.
		/// </summary>
		///<param name="entityInstance"></param>
		///<returns></returns>
		public IList<IInvalidValueInfo> Validate(object entityInstance)
		{
			Type type = entityInstance.GetType();

			var validators = from property in type.GetProperties()
			                 from invalidMessage in GetInvalidValues(entityInstance, property, property.GetValue(entityInstance, null))
			                 select invalidMessage;

			return validators.ToList();
		}

		///<summary>
		/// Validates a property of the entity and returns the information about invalid values.
		///</summary>
		///<param name="entityInstance"></param>
		///<param name="property"></param>
		///<typeparam name="T"></typeparam>
		///<typeparam name="TP"></typeparam>
		///<returns></returns>
		public IList<IInvalidValueInfo> Validate<T, TP>(T entityInstance, Expression<Func<T, TP>> property) where T : class
		{
			MemberInfo propertyInfo = GetMemberInfo(property);
			var value = property.Compile()(entityInstance);

			return GetInvalidValues(entityInstance, propertyInfo, value);
		}

		private static IList<IInvalidValueInfo> GetInvalidValues<T, TP>(T entityInstance, MemberInfo propertyInfo, TP value)
		{
			var validators = propertyInfo.GetCustomAttributes(typeof (ValidationAttribute), true)
				.OfType<ValidationAttribute>();

			var result = from v in validators
			             where !v.IsValid(value)
			             select new InvalidValueInfo(entityInstance.GetType(), propertyInfo.Name, v);

			return result.OfType<IInvalidValueInfo>().ToList();
		}

		private static MemberInfo GetMemberInfo(LambdaExpression lambda)
		{
			return ((MemberExpression)lambda.Body).Member;
		}

		///<summary>
		/// Validates a property of the entity and returns the information about invalid values.
		///</summary>
		///<param name="entityInstance"></param>
		///<param name="property"></param>
		///<typeparam name="T"></typeparam>
		///<typeparam name="TP"></typeparam>
		///<returns></returns>
		public IList<IInvalidValueInfo> Validate(object entityInstance, string property)
		{
			PropertyInfo propertyInfo = entityInstance.GetType().GetProperty(property);
			var value = propertyInfo.GetValue(entityInstance, null);
			return GetInvalidValues(entityInstance, propertyInfo, value);
		}

		#endregion
	}
}