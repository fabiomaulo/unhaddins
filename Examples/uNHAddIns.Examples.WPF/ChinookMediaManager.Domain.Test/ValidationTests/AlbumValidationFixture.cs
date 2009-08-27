using System;
using System.Linq;
using System.Linq.Expressions;
using Castle.Windsor;
using ChinookMediaManager.Domain.Test.Helpers;
using ChinookMediaManager.GuyWire.Configurators;
using NHibernate.Validator.Constraints;
using NHibernate.Validator.Engine;
using NUnit.Framework;

namespace ChinookMediaManager.Domain.Test.ValidationTests
{
    [TestFixture]
    public class AlbumValidationFixture
    {
        private IWindsorContainer container;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            container = new WindsorContainer();
            var configurator = new NHVConfigurator();
            configurator.Configure(container);
        }

        [Test]
        public void title_constraints()
        {
            Attribute constraint = GetConstraint<Album, NotNullNotEmptyAttribute>(a => a.Title);


            GetConstraint<Album, NotNullNotEmptyAttribute>(a => a.Title)
                .Message
                .Should().Be.EqualTo("Title should not be null.");

            GetConstraint<Album, LengthAttribute>(a => a.Title)
                .Should().Be.OfType<LengthAttribute>()
                .And.ValueOf.Message.Should().Be.EqualTo("Title should not exceed 200 chars.");
                
                

            constraint.Should().Not.Be.Null();
        }

        private TConstraintType GetConstraint<T, TConstraintType>(Expression<Func<T, object>> property) where TConstraintType : Attribute
        {
            var propertyName = Strong.Instance<T>
                                     .Property(property)
                                     .Name;

            var ve = container.Resolve<ValidatorEngine>();

            var constraints = ve.GetClassValidator(typeof(T))
                                .GetMemberConstraints(propertyName);

            return (TConstraintType)constraints.Where(a => a.GetType().Equals(typeof(TConstraintType)))
                              .First();
        }
    }
}