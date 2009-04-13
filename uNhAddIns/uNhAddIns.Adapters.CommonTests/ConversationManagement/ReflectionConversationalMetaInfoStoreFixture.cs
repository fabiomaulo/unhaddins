using System;
using System.Linq;
using NUnit.Framework;
using uNhAddIns.Adapters.Common;

namespace uNhAddIns.Adapters.CommonTests.ConversationManagement
{
	[TestFixture]
	public class ReflectionConversationalMetaInfoStoreFixture
	{
		[Test]
		public void AddProtection()
		{
			var store = new ReflectionConversationalMetaInfoStore();
			Assert.Throws<ArgumentNullException>(() => store.Add(null));
		}

		[Test]
		public void ShouldAddConversational()
		{
			var store = new ReflectionConversationalMetaInfoStore();
			store.Add(typeof (SillyCrudModel));
			IConversationalMetaInfoHolder metainfo = store.GetMetadataFor(typeof (SillyCrudModel));
			metainfo.Should().Not.Be.Null();
			metainfo.ConversationalClass.Should().Be.Equal(typeof (SillyCrudModel));
			metainfo.Methods.Should().Not.Be.Empty();
		}

		[Test]
		public void ShouldWorkWithInherited()
		{
			var store = new ReflectionConversationalMetaInfoStore();
			store.Add(typeof (SillyCrudModel));
			store.Add(typeof (InheritedSillyCrudModelWithConcreteConversationCreationInterceptor));
			
			store.MetaData.Count().Should().Be.Equal(2);

			IConversationalMetaInfoHolder metainfo =
				store.GetMetadataFor(typeof (InheritedSillyCrudModelWithConcreteConversationCreationInterceptor));
			
			metainfo.Should().Not.Be.Null();
			metainfo.ConversationalClass.Should().Be.Equal(
				typeof (InheritedSillyCrudModelWithConcreteConversationCreationInterceptor));
			metainfo.Methods.Should().Not.Be.Empty();
		}
	}
}