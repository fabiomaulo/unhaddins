using System.Collections.Specialized;
using System.ComponentModel;
using NHibernate.Engine;
using NHibernate.Util;
using NUnit.Framework;
using uNhAddIns.WPF.Collections;
using uNhAddIns.WPF.Tests.Collections.SampleDomain;

namespace uNhAddIns.WPF.Tests.Collections
{
    [TestFixture]
    public class ObservablePersistentGenericBagFixture : BaseTest
    {

        [Test]
        public void collection_should_implement_inotifycollectionchanged()
        {
            var id = CreateNewInvoice();
            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                invoice.Lines.GetType().ShouldImplement<INotifyCollectionChanged>();
                tx.Commit();
            }
        }

        [Test]
        public void collection_should_implement_inotifypropertychanged()
        {
            var id = CreateNewInvoice();
            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                invoice.Lines.GetType().ShouldImplement<INotifyPropertyChanged>();
                tx.Commit();
            }
        }

        [Test]
        public void add_item_should_raise_propertychanged_for_count()
        {
            var id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();

                ((INotifyPropertyChanged)invoice.Lines).PropertyChanged += (sender, args) =>
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
            var id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();

                ((INotifyPropertyChanged)invoice.Lines).PropertyChanged += (sender, args) =>
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
        public void add_item_should_raise_collectionchanged_properly()
        {
            var id = CreateNewInvoice();
            bool eventWasRaised = false;

            using(var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var newLine = new InvoiceLine();
                
                ((INotifyCollectionChanged)invoice.Lines).CollectionChanged += (sender, args) =>
                        {
                            sender.Should().Be.EqualTo(invoice.Lines);
                            args.Action.Should().Be.EqualTo(NotifyCollectionChangedAction.Add);
                            args.NewItems.Count.Should().Be.EqualTo(1);
                            args.NewItems[0].Should().Be.EqualTo(newLine);
                            eventWasRaised = true;
                        };

                invoice.AddLine(newLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        [Test]
        public void remove_item_should_raise_collectionchanged_properly()
        {
            var id = CreateNewInvoice();
            bool eventWasRaised = false;

            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var invoice = session.Get<Invoice>(id);
                var oldLine = invoice.Lines[0];

                ((INotifyCollectionChanged)invoice.Lines).CollectionChanged += (sender, args) =>
                {
                    sender.Should().Be.EqualTo(invoice.Lines);
                    args.Action.Should().Be.EqualTo(NotifyCollectionChangedAction.Remove);
                    args.OldItems.Count.Should().Be.EqualTo(1);
                    args.OldItems[0].Should().Be.EqualTo(oldLine);
                    eventWasRaised = true;
                };

                invoice.RemoveLine(oldLine);
                eventWasRaised.Should().Be.True();
                tx.Commit();
            }
        }

        private int CreateNewInvoice()
        {
            int id;
            using(var session = sessions.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var invoice = new Invoice();
                invoice.AddLine(new InvoiceLine());
                id = (int)session.Save(invoice);
                tx.Commit();
            }
            return id;
        }
    }
}