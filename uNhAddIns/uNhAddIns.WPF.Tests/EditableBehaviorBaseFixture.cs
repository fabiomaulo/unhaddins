using System;
using System.Reflection;
using NUnit.Framework;

namespace uNhAddIns.WPF.Tests
{
    [TestFixture]
    public class EditableBehaviorBaseFixture
    {
        private class Person
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }

        [Test]
        public void can_apply_temp_values_to_target()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            var person = new Person();
            PropertyInfo nameProperty = typeof (Person).GetProperty("Name");
            PropertyInfo addressProperty = typeof (Person).GetProperty("Address");

            editableBehaviorBase.BeginEdit();

            editableBehaviorBase.StoreTempValue(nameProperty, "Jose");
            editableBehaviorBase.StoreTempValue(addressProperty, "Siempre Viva 123");

            editableBehaviorBase.EndEdit(person);


            person.Name.Should().Be.EqualTo("Jose");
            person.Address.Should().Be.EqualTo("Siempre Viva 123");
        }

        [Test]
        public void can_store_and_retrieve_temp_value()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            PropertyInfo property = typeof (Person).GetProperty("Name");
            editableBehaviorBase.BeginEdit();
            editableBehaviorBase.StoreTempValue(property, "Jose");
            editableBehaviorBase.GetTempValue(property).Should().Be.EqualTo("Jose");
        }

        [Test]
        public void store_without_beginedit_throw_exception()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            PropertyInfo property = typeof(Person).GetProperty("Name");
            new Action(() => editableBehaviorBase.StoreTempValue(property, "Jose"))
                .Should().Throw<InvalidOperationException>();
            
        }

        [Test]
        public void canceledit_without_beginedit_throw_exception()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            new Action(editableBehaviorBase.CancelEdit)
                .Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void double_begin_edit_throw_exception()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            editableBehaviorBase.BeginEdit();
            new Action(editableBehaviorBase.BeginEdit)
                .Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void endedit_without_beginedit_throw_exception()
        {
            var editableBehaviorBase = new EditableBehaviorBase();
            new Action(() => editableBehaviorBase.EndEdit(new object()))
                .Should().Throw<InvalidOperationException>();
        }
    }
}