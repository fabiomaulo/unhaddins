using System.Collections;
using NHibernate;
using NUnit.Framework;

namespace uNhAddIns.Test.UserTypes
{
    [TestFixture]
	public class EncryptedStringFixture : TestCase
    {
        protected override IList Mappings
        {
            get { return new string[] { "UserTypes.User.hbm.xml" }; }
        }

        protected override void OnTearDown()
        {
            using (ISession s = OpenSession())
            {
                s.Delete("from User");
                s.Flush();
            }
        }

        [Test]
        public void SaveEncryptedPassword()
        {
            User user = new User(1, "Astor Piazolla", "tango");

            using (ISession s = OpenSession())
            {
                s.Save(user);
                s.Flush();
            }

            using (ISession s = OpenSession())
            {
                User decryptedUser = s.Get<User>(1);
                
                Assert.AreEqual(1,decryptedUser.Id);
                Assert.AreEqual("Astor Piazolla", decryptedUser.Name);
                Assert.AreEqual("tango", decryptedUser.Password);
            }
        }

        [Test]
        public void SaveNullPropertyAndGetItBack()
        {
            User user = new User(2, "Pat Metheny", null);

            using (ISession s = OpenSession())
            {
                s.Save(user);
                s.Flush();
            }

            using (ISession s = OpenSession())
            {
                User decryptedUser = s.Get<User>(2);

				Assert.AreEqual(2, decryptedUser.Id);
				Assert.AreEqual("Pat Metheny", decryptedUser.Name);
				Assert.IsNull(decryptedUser.Password);
            }

        }
    }
}