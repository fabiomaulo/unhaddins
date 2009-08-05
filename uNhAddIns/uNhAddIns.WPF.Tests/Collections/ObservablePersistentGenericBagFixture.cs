using System;
using System.Collections.Specialized;
using System.ComponentModel;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.WPF.Tests.SampleDomain;

namespace uNhAddIns.WPF.Tests.Collections
{
    [TestFixture]
    public class ObservablePersistentGenericBagFixture : IntegrationBaseTest
    {
        private int CreateNewInvoice()
        {
            int id;
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = new Invoice();
                invoice.AddLine(new InvoiceLine());
                id = (int) session.Save(invoice);
                tx.Commit();
            }
            return id;
        }

        [Test]
        public void add_item_should_raise_collectionchanged_properly()
        {
            int id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();

                ((INotifyCollectionChanged) invoice.Lines).CollectionChanged += (sender, args) =>
                                                                                    {
                                                                                        sender.Should().Be.EqualTo(
                                                                                            invoice.Lines);
                                                                                        args.Action.Should().Be.EqualTo(
                                                                                            NotifyCollectionChangedAction
                                                                                                .Add);
                                                                                        args.NewItems.Count.Should().Be.
                                                                                            EqualTo(1);
                                                                                        args.NewItems[0].Should().Be.
                                                                                            EqualTo(newLine);
                                                                                        eventWasRaised = true;
                                                                                    };

                invoice.AddLine(newLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        [Test]
        public void add_item_should_raise_propertychanged_for_count()
        {
            int id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();

                ((INotifyPropertyChanged) invoice.Lines).PropertyChanged += (sender, args) =>
                                                                                {
                                                                                    if (args.PropertyName == "Count")
                                                                                        eventWasRaised = true;
                                                                                };

                invoice.AddLine(newLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        [Test]
        public void add_item_should_raise_propertychanged_for_item()
        {
            int id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();

                ((INotifyPropertyChanged) invoice.Lines).PropertyChanged += (sender, args) =>
                                                                                {
                                                                                    if (args.PropertyName == "Item[]")
                                                                                        eventWasRaised = true;
                                                                                };

                invoice.AddLine(newLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        [Test]
        public void collection_should_implement_inotifycollectionchanged()
        {
            int id = CreateNewInvoice();
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                typeof (INotifyCollectionChanged)
                    .Should().Be.AssignableFrom(invoice.Lines.GetType());
                tx.Commit();
            }
        }

        [Test]
        public void collection_should_implement_inotifypropertychanged()
        {
            int id = CreateNewInvoice();
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);

                typeof (INotifyPropertyChanged)
                    .Should().Be.AssignableFrom(invoice.Lines.GetType());
                tx.Commit();
            }
        }

        [Test]
        public void remove_item_should_raise_collectionchanged_properly()
        {
            int id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                InvoiceLine oldLine = invoice.Lines[0];

                ((INotifyCollectionChanged) invoice.Lines).CollectionChanged += (sender, args) =>
                                                                                    {
                                                                                        sender.Should().Be.EqualTo(
                                                                                            invoice.Lines);
                                                                                        args.Action.Should().Be.EqualTo(
                                                                                            NotifyCollectionChangedAction
                                                                                                .Remove);
                                                                                        args.OldItems.Count.Should().Be.
                                                                                            EqualTo(1);
                                                                                        args.OldItems[0].Should().Be.
                                                                                            EqualTo(oldLine);
                                                                                        eventWasRaised = true;
                                                                                    };

                invoice.RemoveLine(oldLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        #region "IEditableObject behavior"

        [Test]
        public void invalid_calls_for_ieditableobject_methods()
        {
            int id = CreateNewInvoice();

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);

                new Action(() => ((IEditableObject) invoice.Lines).EndEdit())
                    .Should().Throw<InvalidOperationException>()
                    .And.ValueOf.Message.Should().Be.EqualTo("EndEdit without BeginEdit");

                new Action(() => ((IEditableObject)invoice.Lines).CancelEdit())
                    .Should().Throw<InvalidOperationException>()
                    .And.ValueOf.Message.Should().Be.EqualTo("CancelEdit without BeginEdit");

                ((IEditableObject)invoice.Lines).BeginEdit();

                new Action(() => ((IEditableObject)invoice.Lines).BeginEdit())
                    .Should().Throw<InvalidOperationException>()
                    .And.ValueOf.Message.Should().Be.EqualTo("The collection is already in EditMode");

                tx.Commit();
            }
        }


        [Test]
        public void add_item_and_cancel_should_revert_changes()
        {
            int id = CreateNewInvoice();

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                //at this point invoice has 1 line.

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).CancelEdit();

                invoice.Lines.Count.Should().Be.EqualTo(1);
                session.IsDirty().Should().Be.False();
                tx.Commit();
            }
        }

        [Test]
        public void add_item_and_end_should_work()
        {
            int id = CreateNewInvoice();

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                //at this point invoice has 1 line.

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).EndEdit();

                invoice.Lines.Count.Should().Be.EqualTo(2);
                session.IsDirty().Should().Be.True();

                tx.Commit();
            }
        }
        
        [Test]
        public void end_edit_and_cancel_edit_should_work()
        {
            int id = CreateNewInvoice();

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                //at this point invoice has 1 line.

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).EndEdit();

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).CancelEdit();

                invoice.Lines.Count.Should().Be.EqualTo(2);
                session.IsDirty().Should().Be.True();

                tx.Commit();
            }
        }

        [Test]
        public void cancel_edit_and_end_edit_should_work()
        {
            int id = CreateNewInvoice();

            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                //at this point invoice has 1 line.

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).CancelEdit();

                ((IEditableObject)invoice.Lines).BeginEdit();
                invoice.AddLine(new InvoiceLine());
                ((IEditableObject)invoice.Lines).EndEdit();

                invoice.Lines.Count.Should().Be.EqualTo(2);
                session.IsDirty().Should().Be.True();

                tx.Commit();
            }
        }
        #endregion
    }
}