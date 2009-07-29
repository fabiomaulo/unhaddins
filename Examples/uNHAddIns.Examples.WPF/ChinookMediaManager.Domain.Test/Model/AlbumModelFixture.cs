using System.Collections.Generic;
using System.Linq;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Impl;
using Moq;
using NUnit.Framework;


namespace ChinookMediaManager.Domain.Test.Model
{
    [TestFixture]
    public class AlbumModelFixture
    {
        private static IList<IAlbum> CreateSampleAlbumsForArtist(Artist artist)
        {
            return new List<IAlbum>
                       {
                           new Album {Artist = artist, Title = "A"},
                           new Album {Artist = artist, Title = "B"},
                       };
        }

        [Test]
        public void can_get_albums_from_artist()
        {
            var artist = new Artist {Name = "A"};
            IList<IAlbum> albums = CreateSampleAlbumsForArtist(artist);
            var albumRepository = new Mock<IAlbumRepository>();

            albumRepository.Setup(ar => ar.GetByArtist(artist))
                .Returns(albums).AtMostOnce();

            var albumModel = new AlbumManagerModel(albumRepository.Object);

            IEnumerable<IAlbum> result = albumModel.GetAlbumsByArtist(artist);

            result.Count().Should().Be.EqualTo(2);


            albumRepository.VerifyAll();
        }

        [Test]
        public void can_save_album()
        {
            var albumRepository = new Mock<IAlbumRepository>();
            var album = new Album();

            albumRepository.Setup(ar => ar.MakePersistent(album))
                           .Returns(album).AtMostOnce();


            var albumModel = new AlbumManagerModel(albumRepository.Object);

            albumModel.Save(album);

            albumRepository.VerifyAll();
        }
    }
}