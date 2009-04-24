using System;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Spring.Context.Support;
using uNhAddIns.Adapters.CommonTests.ConversationManagement;

namespace uNhAddIns.SpringAdapters.Tests.ConversationManagement
{
	[TestFixture]
	public class ConversationInterceptorFixture : ConversationFixtureBase
	{
		protected override IServiceLocator NewServiceLocator()
		{
			var context = new StaticApplicationContext();
			throw new NotImplementedException();
		}

		protected override void RegisterAsTransient<TService, TImplementor>(IServiceLocator serviceLocator)
		{
			throw new NotImplementedException();
		}

		protected override void RegisterInstanceForService<T>(IServiceLocator serviceLocator, T instance)
		{
			throw new NotImplementedException();
		}
	}
}