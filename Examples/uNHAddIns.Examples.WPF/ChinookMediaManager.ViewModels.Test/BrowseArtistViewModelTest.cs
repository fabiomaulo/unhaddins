using System.Collections.Generic;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using Moq;
using NUnit.Framework;

namespace ChinookMediaManager.ViewModels.Test
{
    [TestFixture]
    public class BrowseArtistViewModelTest
    {
        [Test]
        public void canexecute_editalbums_command_if_no_artist_selected_should_be_false()
        {
            var artistModel = new Mock<IBrowseArtistModel>();
            var viewInstantiator = new Mock<IViewFactory>();

            var browseArtistVm = new BrowseArtistViewModel(artistModel.Object, viewInstantiator.Object);

            browseArtistVm.SelectedArtist = null;

            browseArtistVm.EditAlbumsCommand.CanExecute(null).Should().Be.False();
        }


        [Test]
        public void execute_editalbums_command_should_setup_albummanager_properly()
        {
            var artistModel = new Mock<IBrowseArtistModel>();
            var viewInstantiator = new Mock<IViewFactory>();
            var albumManagerViewModel = new Mock<AlbumManagerViewModel>(null,null);
            var artist = new Artist {Name = "John"};
			
            albumManagerViewModel.Setup(amvm => amvm.SetUp(artist))
                .AtMostOnce();

            viewInstantiator.Setup(vi => vi.ShowView<AlbumManagerViewModel>())
                .Returns(albumManagerViewModel.Object)
                .AtMostOnce();

            var browseArtistVm = new BrowseArtistViewModel(
                artistModel.Object,
                viewInstantiator.Object);

            browseArtistVm.SelectedArtist = artist;

            browseArtistVm.EditAlbumsCommand.CanExecute(null).Should().Be.True();

            browseArtistVm.EditAlbumsCommand.Execute(null);


            viewInstantiator.VerifyAll();
            albumManagerViewModel.VerifyAll();
        }

        [Test]
        public void load_list_command_should_load_artists_coll()
        {
            var artistModel = new Mock<IBrowseArtistModel>();
            var viewInstantiator = new Mock<IViewFactory>();

            var artists = new List<Artist> {new Artist {Name = "Jose"}};

            artistModel.Setup(am => am.GetAllArtists()).Returns(artists);

            var browseArtistVm = new BrowseArtistViewModel(artistModel.Object, viewInstantiator.Object);

            browseArtistVm.LoadListCommand.CanExecute(null).Should().Be.True();

            browseArtistVm.LoadListCommand.Execute(null);

            browseArtistVm.Artists.Should().Be.SameInstanceAs(artists);
        }
    }
}