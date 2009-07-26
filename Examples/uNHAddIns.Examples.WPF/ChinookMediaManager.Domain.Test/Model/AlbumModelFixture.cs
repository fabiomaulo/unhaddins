using System.Collections.Generic;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Impl;
using NUnit.Framework;
using Rhino.Mocks;
using System.Linq;

namespace ChinookMediaManager.Domain.Test.Model
{
    [TestFixture]
    public class AlbumModelFixture 
    {
        private MockRepository _mocks;

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            _mocks = new MockRepository();
        }

        [Test]
        public void can_get_albums_from_artist()
        {
            var artist = new Artist {Name = "A"};
            var albums = CreateSampleAlbumsForArtist(artist);
            albums.Add(new Album{ Artist = new Artist(), Title = "C" });

            IAlbumRepository albumRepository = _mocks.DynamicMock<IAlbumRepository>();

            using(_mocks.Record())
            {
                Expect.Call(albumRepository.GetEnumerator())
                      .Return(albums.GetEnumerator());
            }

            var albumModel = new AlbumManagementModel(albumRepository);

            using(_mocks.Playback())
            {
                var result = albumModel.GetAlbumsOfArtist(artist);

                result.Count().Should().Be.EqualTo(2);
                foreach (var album in result)
                    album.Artist.Should().Be.EqualTo(artist);
            }
        }





        private static IList<Album> CreateSampleAlbumsForArtist(Artist artist)
        {
            return new List<Album>()
                             {
                                 new Album {Artist = artist, Title = "A"},
                                 new Album {Artist = artist, Title = "B"},
                             };
        }
    }
}