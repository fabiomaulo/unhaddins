using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;

namespace uNhAddIns.Adapters.CommonTests.AttributesDefaults
{
	[TestFixture]
	public class PersistenceConversationalAttributeFixture
	{
		[Test]
		public void ShouldWorkWithDefaultValues()
		{
			// This test is useful to check future Breaking-changes
			var a = new PersistenceConversationalAttribute();
			Assert.That(a.ConversationCreationInterceptor, Is.Null);
			Assert.That(a.ConversationId, Is.Null);
			Assert.That(a.DefaultEndMode, Is.EqualTo(EndMode.Continue));
			Assert.That(a.IdPrefix, Is.Null);
			Assert.That(a.MethodsIncludeMode, Is.EqualTo(MethodsIncludeMode.Implicit));
			Assert.That(a.UseConversationCreationInterceptorConvention, Is.True);
		}
	}
}