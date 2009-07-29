using System.Collections.Generic;
using Caliburn.Testability.Assertions;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;
using Moq;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test
{
    [TestFixture]
    public class BrowseArtistPresenterFixture
    {
        [Test]
        public void can_browse_artist()
        {
            var browseArtistModelMoq = new Mock<IBrowseArtistModel>();
            var presenterFactory = new Mock<IPresenterFactory>();

            var artists = new List<Artist>();

            browseArtistModelMoq.Setup(model => model.GetAllArtists())
                .Returns(() => artists)
                .AtMostOnce();

            var browseArtist = new BrowseArtistPresenter(browseArtistModelMoq.Object,
                                                         presenterFactory.Object);


            //TODO: find a better syntax for this.
            var propertyHasChangedAssertion =
                new PropertyHasChangedAssertion<BrowseArtistPresenter, IList<Artist>>(browseArtist, b => b.Artists);

            //the action under test.
            propertyHasChangedAssertion.When(browseArtist.LoadList);

            browseArtist.Artists.Should().Be.SameInstanceAs(artists);

            browseArtistModelMoq.VerifyAll();
        }


        [Test]
        public void edit_albums_should_work()
        {
            var browseArtistModelMoq = new Mock<IBrowseArtistModel>();
            var presenterFactory = new Mock<IPresenterFactory>();
            var albumManagerMoq = new Mock<IAlbumManagerPresenter>();
            albumManagerMoq.Setup(am => am.OpenView(It.IsAny<Artist>())).AtMostOnce();

            presenterFactory.Setup(pf => pf.GetPresenter<IAlbumManagerPresenter>())
                            .Returns(albumManagerMoq.Object)
                            .AtMostOnce();

            var browseArtist = new BrowseArtistPresenter(browseArtistModelMoq.Object,
                                                         presenterFactory.Object);

            var artist = new Artist {Name = "Rolling Stones"};

            browseArtist.EditAlbums(artist);


            presenterFactory.Verify(pf => pf.GetPresenter<IAlbumManagerPresenter>());
            albumManagerMoq.Verify(a => a.OpenView(artist));

        }
    }
}