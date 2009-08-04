using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ChinookMediaManager.Domain.Impl;
using ChinookMediaManager.Domain.Model;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.SessionEasier.Conversations;

namespace ChinookMediaManager.Domain.Test.Model
{
    [TestFixture]
    public class AlbumModelFixture : TestModelBase
    {
        private ConversationObserver<AlbumManagerModel> conversationObserver;
        private IAlbumManagerModel albumModel;

        public override void OnSetup()
        {
            conversationObserver = (ConversationObserver<AlbumManagerModel>) container
                                                                                 .Resolve
                                                                                 <
                                                                                 IConversationCreationInterceptorConvention
                                                                                 <AlbumManagerModel>>();
            albumModel = container.Resolve<IAlbumManagerModel>();
        }

        private Artist GetAcDc()
        {
            Artist artist;

            using (ISession session = sessions.OpenSession())
            {
                artist = session.Get<Artist>(1);
            }
            return artist;
        }

        [Test]
        public void can_get_albums_from_artist()
        {
            bool conversationWasPaused = false;
            Artist artist = GetAcDc();

            conversationObserver.Paused += (sender, args) => { conversationWasPaused = true; };

            IList<IAlbum> albums = albumModel.GetAlbumsByArtist(artist).ToList();

            conversationWasPaused.Should().Be.True();

            albums.Count.Should().Be.EqualTo(2);
        }

        [Test]
        public void track_list_should_implement_collectionchanged()
        {
            Artist artist = GetAcDc();

            IList<IAlbum> albums = albumModel.GetAlbumsByArtist(artist).ToList();

            albums[0].Tracks.GetType().Should().Be.AssignableTo(typeof (INotifyCollectionChanged));
        }

        [Test]
        public void acceptalll_end_the_conversation()
        {
            Assert_Was_Ended(albumModel.AceptAll, conversationObserver);
        }
        
        [Test]
        public void cancelall_end_the_conversation()
        {
            Assert_Was_Aborted(albumModel.CancelAll, conversationObserver);
        }
    }
}