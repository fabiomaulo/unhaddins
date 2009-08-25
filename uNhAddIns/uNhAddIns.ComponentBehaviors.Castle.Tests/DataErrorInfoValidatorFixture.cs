using System;
using System.ComponentModel;
using Castle.Windsor;
using NHibernate.Validator.Cfg.Loquacious;
using NHibernate.Validator.Constraints;
using NHibernate.Validator.Engine;
using NUnit.Framework;
using uNhAddIns.Adapters;
using uNhAddIns.NHibernateValidator;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests
{
    public class Person
    {
        [Length(5, Message = "Lenght should be 2.")]
        [Email(Message = "Should be email address.")]
        public string Mail { get; set; }
    }

    [TestFixture]
    public class DataErrorInfoValidatorFixture
    {
        private IWindsorContainer container;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            container = new WindsorContainer();
            var ve = new ValidatorEngine();

            container.AddFacility<ComponentBehaviorsFacility>();

            container.Register(Component.For<IEntityValidator>()
                                   .ImplementedBy<EntityValidator>());

            container.Register(Component.For<ValidatorEngine>()
                                   .Instance(ve)
                                   .LifeStyle.Singleton);

            var configure = new FluentConfiguration();

            configure.Register(typeof (Person).Assembly.ValidationDefinitions())
                .SetDefaultValidatorMode(ValidatorMode.UseAttribute)
                .IntegrateWithNHibernate.ApplyingDDLConstraints().And.RegisteringListeners();

            ve.Configure(configure);


            container.Register(Component.For<Person>()
                                   .ImplementedBy<Person>()
                                   .AddDataErrorInfoBehavior()
                                   .LifeStyle.Transient);
        }

        [Test]
        public void error_should_work()
        {
            var person = container.Resolve<Person>();

            person.Mail = "aaaaaaa";

            string[] errorMessages = ((IDataErrorInfo) person).Error
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            errorMessages.Length.Should().Be.EqualTo(2);

            errorMessages.Should().Contain("Lenght should be 2.")
                .And.Contain("Should be email address.");
        }

        [Test]
        public void get_item_should_work()
        {
            var person = container.Resolve<Person>();

            person.Mail = "aaaaaaa";

            string[] errorMessages = ((IDataErrorInfo) person)["Mail"]
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            errorMessages.Length.Should().Be.EqualTo(2);

            errorMessages.Should().Contain("Lenght should be 2.")
                .And.Contain("Should be email address.");
        }
    }
}