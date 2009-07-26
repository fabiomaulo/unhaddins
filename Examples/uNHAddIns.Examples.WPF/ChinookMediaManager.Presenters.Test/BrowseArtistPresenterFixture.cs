using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Testability.Assertions;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
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
            var albumManagerMoq = new Mock<IAlbumManagementPresenter>();

            var artists = new List<Artist>();

            browseArtistModelMoq.Setup(model => model.GetAllArtists())
                .Returns(() => artists)
                .AtMostOnce();

            var browseArtist = new BrowseArtistPresenter(browseArtistModelMoq.Object,
                                                         albumManagerMoq.Object);


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
            var albumManagerMoq = new Mock<IAlbumManagementPresenter>();


            albumManagerMoq.Setup(am => am.OpenView(null, null)).AtMostOnce();
            
            var browseArtist = new BrowseArtistPresenter(browseArtistModelMoq.Object,
                                                         albumManagerMoq.Object);

            var artist = new Artist {Name = "Rolling Stones"};

            browseArtist.EditAlbums(artist);


            albumManagerMoq.Verify(a => a.OpenView(browseArtist, artist));
        }
    }
}