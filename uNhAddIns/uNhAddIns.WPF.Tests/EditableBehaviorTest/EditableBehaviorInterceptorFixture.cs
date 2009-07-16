using System.ComponentModel;
using System.Linq;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace uNhAddIns.WPF.Tests.EditableBehaviorTest
{
    [TestFixture]
    public class EditableBehaviorInterceptorFixture
    {
        public class Person
        {
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
        }


        public Person CreateProxiedPerson()
        {
            var proxyGenerator = new ProxyGenerator();
            //Note: use without args when inject into the container (IOnBehalfAware)
            return (Person) proxyGenerator.CreateClassProxy(typeof (Person),
                                                            new[] {typeof (IEditableObject)},
                                                            new[] {new EditableBehaviorInterceptor(typeof(Person))});
        }

        [Test]
        public void cancel_should_return_previous_values()
        {
            Person person = CreateProxiedPerson();
            var editablePerson = ((IEditableObject) person);

            person.Name = "Jose";
            person.Address = "Siempre Viva 1234";

            editablePerson.BeginEdit();
            person.Name = "Juan";
            person.Address = "Siempre Viva 5678";
            editablePerson.CancelEdit();

            person.Address.Should().Be.EqualTo("Siempre Viva 1234");
            person.Name.Should().Be.EqualTo("Jose");
        }

        [Test]
        public void endedit_should_apply_changes()
        {
            Person person = CreateProxiedPerson();
            var editablePerson = ((IEditableObject) person);

            person.Name = "Jose";
            person.Address = "Siempre Viva 1234";

            editablePerson.BeginEdit();
            person.Name = "Juan";
            person.Address = "Siempre Viva 5678";
            editablePerson.EndEdit();

            person.Address.Should().Be.EqualTo("Siempre Viva 5678");
            person.Name.Should().Be.EqualTo("Juan");
        }

        [Test]
        public void work_properly_in_edit_mode()
        {
            Person person = CreateProxiedPerson();
            var editablePerson = ((IEditableObject) person);

            person.Name = "Pedro";

            editablePerson.BeginEdit();
            person.Name = "Jose";

            person.Name.Should().Be.EqualTo("Jose");
        }
    }
}