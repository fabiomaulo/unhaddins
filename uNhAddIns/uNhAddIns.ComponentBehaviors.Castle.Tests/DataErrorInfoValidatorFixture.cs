using System;
using System.ComponentModel;
using Castle.Windsor;
using Moq;
using NUnit.Framework;
using uNhAddIns.Adapters;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests
{
    public class Person 
    {
        public virtual string Mail { get; set; }
    }

    [TestFixture]
    public class DataErrorInfoValidatorFixture
    {
        private IWindsorContainer container;

        private static IEntityValidator CreateMockedEntityValidator()
        {
            var invalid1 = new Mock<IInvalidValueInfo>();
            var invalid2 = new Mock<IInvalidValueInfo>();
            invalid1.SetupGet(i => i.Message).Returns("Lenght should be 2.");
            invalid2.SetupGet(i => i.Message).Returns("Should be email address.");

            var entityValidator = new Mock<IEntityValidator>();
            entityValidator.Setup(ev => ev.Validate(It.IsAny<object>()))
                .Returns(new []{ invalid1.Object, invalid2.Object})
                .Callback<object>(o =>
                 {
                    if (!o.GetType().Equals(typeof (Person)))
                    {
                        Assert.Fail("You should give me the target. Not proxy.");
                    }
                 }
                );
            
            entityValidator.Setup(ev=>ev.Validate(It.IsAny<object>(), It.IsAny<string>()))
                           .Returns(new[] { invalid1.Object, invalid2.Object })
                .Callback<object,string>((o,s) =>
                {
                    if (!o.GetType().Equals(typeof(Person)))
                    {
                        Assert.Fail("You should give me the target. Not proxy.");
                    }
                }
                );

            return entityValidator.Object;
        }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            container = new WindsorContainer();

            //Add the facility
            container.AddFacility<ComponentBehaviorsFacility>();

            //configure behaviors
            var config = new DefaultBehaviorStore();
            
            config.SetBehaviors(typeof(Person), Behaviors.DataErrorInfoBehavior);

            container.Register(Component.For<IBehaviorStore>().Instance(config));

            //Register a mock instance of EntityValidator.
            container.Register(Component.For<IEntityValidator>()
                                        .Instance(CreateMockedEntityValidator())
                                        .LifeStyle.Singleton);

            //Register the entity
            container.Register(Component.For<Person>()
                                        .LifeStyle.Transient);
        }


        [Test]
        public void get_error_should_work()
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