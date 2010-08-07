using System;
using System.Collections.Generic;
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
			GetConstraint<Album, NotEmptyAttribute>(a => a.Title)
				.Message
				.Should().Be.EqualTo("Title should not be null.");

			GetConstraint<Album, LengthAttribute>(a => a.Title)
				.Should().Be.OfType<LengthAttribute>()
				.And.ValueOf.Message.Should().Be.EqualTo("Title should not exceed 200 chars.");
				
			
		}

		private TConstraintType GetConstraint<T, TConstraintType>(Expression<Func<T, object>> property) where TConstraintType : Attribute
		{
			var propertyName = Strong.Instance<T>
									 .Property(property)
									 .Name;

			var ve = container.Resolve<ValidatorEngine>();

			var constraints = ve.GetClassValidator(typeof(T))
								.GetMemberConstraints(propertyName);

			ICollection<Attribute> matchedConstraints = constraints.Where(a => a.GetType().Equals(typeof(TConstraintType))).ToArray();
			
			matchedConstraints.Count.Should(string.Format("{0}.{1} doesn't have a {2} constraint", 
											typeof (T).Name,
											propertyName, 
											typeof (TConstraintType).Name))
									.Be.GreaterThan(0);

			return (TConstraintType)matchedConstraints.First();
		}
	}
}