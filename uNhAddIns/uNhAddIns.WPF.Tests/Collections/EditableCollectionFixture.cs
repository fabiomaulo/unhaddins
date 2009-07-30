using System;
using NUnit.Framework;
using uNhAddIns.WPF.Collections;

namespace uNhAddIns.WPF.Tests.Collections
{
    [TestFixture]
    public class EditableCollectionFixture
    {
        [Test]
        public void can_add_and_cancel()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };
            
            editableList.BeginEdit();
            editableList.Add("f");
            editableList.CancelEdit();

            editableList.Should().Have.SameSequenceAs("a,b,c".Split(','));
            

        }

        [Test]
        public void can_remove_and_cancel()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            editableList.BeginEdit();
            editableList.Remove("c");
            editableList.CancelEdit();

            editableList.Should().Have.SameSequenceAs("a,b,c".Split(','));

        }

        [Test]
        public void can_clear_and_cancel()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            editableList.BeginEdit();
            editableList.Clear();
            editableList.CancelEdit();

            editableList.Should().Have.SameSequenceAs("a,b,c".Split(','));

        }

        [Test]
        public void can_replace_and_cancel()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            editableList.BeginEdit();
            editableList[0] = "d";
            editableList.CancelEdit();

            editableList.Should().Have.SameSequenceAs("a,b,c".Split(','));

        }
        
        [Test]
        public void can_add_and_commit()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            editableList.BeginEdit();
            editableList.Add("f");
            editableList.EndEdit();

            editableList.Should().Have.SameSequenceAs("a,b,c,f".Split(','));
        }

        [Test]
        public void cancel_edit_without_beginedit_should_throw_inopex()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            new Action(editableList.CancelEdit)
                .Should().Throw<InvalidOperationException>()
                .And.ValueOf.Message.Should().Be.EqualTo("CancelEdit without a BeginEdit");
        }

        [Test]
        public void end_edit_without_beginedit_should_throw_inopex()
        {
            var editableList = new EditableCollection<string>
                                   {
                                       "a","b","c"
                                   };

            new Action(editableList.EndEdit)
                .Should().Throw<InvalidOperationException>()
                .And.ValueOf.Message.Should().Be.EqualTo("EndEdit without a BeginEdit");
        }
    }
}