using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Testability;
using ChinookMediaManager.ViewModels;
using NUnit.Framework;

namespace ChinookMediaManager.View.Test
{
	[TestFixture]
	public class TestDataBindings
	{
		private static Type GetViewForViewModel(Type viewModelType)
		{
			string viewName = viewModelType.Name.Replace("ViewModel", "View");
			string viewFullName = string.Format("ChinookMediaManager.GUI.Views.{0}, ChinookMediaManager.GUI", viewName);
			Type viewType = Type.GetType(viewFullName, true);
			return viewType;
		}

		public static BindingValidator ValidatorFor(Type guiElement, Type presenterType)
		{
			var boundType = new BoundType(presenterType);
			object instance = Activator.CreateInstance(guiElement);
			return new BindingValidator(Bound.DependencyObject((DependencyObject) instance, boundType));
		}

		[Test]
		public void AllDatabindingsAreOkay()
		{
			bool shouldFail = false;

			Type examplePresenterType = typeof (AlbumManagerViewModel);

			IEnumerable<Type> presenterTypes = examplePresenterType.Assembly.GetTypes()
				.Where(type => type.Namespace.EndsWith("ViewModels"));

			foreach (var presenterType in presenterTypes)
			{
				Type viewType = GetViewForViewModel(presenterType);
				Console.WriteLine("validating: {0} - {1}", presenterType.Name, viewType.Name);
				BindingValidator validator = ValidatorFor(viewType, presenterType);

				ValidationResult validatorResult = validator.Validate();

				if (validatorResult.HasErrors)
				{
					Console.WriteLine(validatorResult.ErrorSummary);
					shouldFail = true;
				}
			}

			shouldFail.Should().Be.False();
		}
	}
}