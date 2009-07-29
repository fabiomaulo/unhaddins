using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Testability;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test.BindingTest
{
    [TestFixture]
    public class GlobalDataBinding
    {
        //this is like my view strategy.
        private static Type GetViewForPresenter(Type modelType)
        {
            string className = modelType.Name.Substring(0, modelType.Name.IndexOf("Presen")) + "View";
            //remove I from the interface..
            className = className.Substring(1);
            string fullClassName = string.Format("ChinookMediaManager.GUI.Views.{0}, ChinookMediaManager.GUI", className);
            return Type.GetType(fullClassName, true);
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
            Type examplePresenterType = typeof (AlbumManagerPresenter);

            IEnumerable<Type> presenterTypes = examplePresenterType.Assembly.GetTypes()
                .Where(type => typeof (IPresenter).IsAssignableFrom(type) &&
                               type.IsInterface);

            foreach (Type presenterType in presenterTypes)
            {
                Type viewType = GetViewForPresenter(presenterType);
                BindingValidator validator = ValidatorFor(viewType, presenterType);
                ValidationResult validatorResult = validator.Validate();

                validatorResult.HasErrors
                    .Should(validatorResult.ErrorSummary)
                    .Be.False();

            }
        }
    }
}