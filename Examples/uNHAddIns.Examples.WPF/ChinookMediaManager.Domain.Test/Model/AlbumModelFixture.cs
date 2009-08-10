using System.Collections.Generic;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Impl;
using ChinookMediaManager.Domain.Test.Helpers;
using Moq;
using NUnit.Framework;
using uNhAddIns.Adapters;
using uNhAddIns.Adapters.Common;

namespace ChinookMediaManager.Domain.Test.Model
{
    [TestFixture]
    public class AlbumModelFixture
    {

        private ReflectionConversationalMetaInfoStore conversationalMetaInfoStore 
            = new ReflectionConversationalMetaInfoStore();

        private IConversationalMetaInfoHolder metaInfo;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            conversationalMetaInfoStore.Add(typeof (AlbumManagerModel));
            metaInfo = conversationalMetaInfoStore.GetMetadataFor(typeof(AlbumManagerModel));
        }

        [Test]
        public void can_cancel_album()
        {
            var repository = new Mock<IAlbumRepository>();
            var album = new Album();
            repository.Setup(rep => rep.MakePersistent(It.IsAny<Album>())).Returns(album).AtMostOnce();

            var albumManagerModel = new AlbumManagerModel(repository.Object);

            albumManagerModel.CancelAlbum(album);

            repository.Verify(rep => rep.Refresh(album));
        }

        [Test]
        public void can_get_all_albums_by_artist()
        {
            var artist = new Artist();
            var albums = new List<Album> {new Album()};
            var repository = new Mock<IAlbumRepository>();

            repository.Setup(rep => rep.GetByArtist(It.IsAny<Artist>()))
                .Returns(albums).AtMostOnce();

            var albumManagerModel = new AlbumManagerModel(repository.Object);

            albumManagerModel.GetAlbumsByArtist(artist);

            repository.Verify(rep => rep.GetByArtist(artist));
        }

        [Test]
        public void can_save_album()
        {
            var repository = new Mock<IAlbumRepository>();
            var album = new Album();
            repository.Setup(rep => rep.MakePersistent(It.IsAny<Album>())).Returns(album).AtMostOnce();

            var albumManagerModel = new AlbumManagerModel(repository.Object);

            albumManagerModel.SaveAlbum(album);

            repository.Verify(rep => rep.MakePersistent(album));
        }

        [Test]
        public void model_represents_conversation()
        {
            metaInfo.Should().Not.Be.Null();
            metaInfo.Setting.DefaultEndMode.Should().Be.EqualTo(EndMode.Continue);
            metaInfo.Setting.MethodsIncludeMode.Should().Be.EqualTo(MethodsIncludeMode.Implicit);
        }

        [Test]
        public void cancel_all_abort_the_conversation()
        {
            var method = Strong.Instance<AlbumManagerModel>
                .Method(am => am.CancelAll());

            var conversationInfo = metaInfo.GetConversationInfoFor(method);

            conversationInfo.ConversationEndMode
                            .Should().Be.EqualTo(EndMode.Abort);
        }
        
        [Test]
        public void save_all_end_the_conversation()
        {
            var method = Strong.Instance<AlbumManagerModel>
                .Method(am => am.SaveAll());

            var conversationInfo = metaInfo.GetConversationInfoFor(method);
    
            conversationInfo.ConversationEndMode
                            .Should().Be.EqualTo(EndMode.End);
        }
    }
}