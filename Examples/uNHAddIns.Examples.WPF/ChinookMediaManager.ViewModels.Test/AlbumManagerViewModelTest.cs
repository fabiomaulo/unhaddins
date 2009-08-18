using System.Collections.Generic;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.Infrastructure;
using Moq;
using NUnit.Framework;

namespace ChinookMediaManager.ViewModels.Test
{
    [TestFixture]
    public class AlbumManagerViewModelTest
    {
        [Test]
        public void can_setup_viewmodel()
        {
            var albumManagerModel = new Mock<IAlbumManagerModel>();
            var viewInsantiator = new Mock<IViewFactory>();

            var artist = new Artist { Name = "John" };
            var albumList = new List<Album> { new Album() { Artist = artist } };

            albumManagerModel.Setup(am => am.GetAlbumsByArtist(artist))
                             .Returns(albumList)
                             .AtMostOnce();


            var albumManagerVm = new AlbumManagerViewModel(albumManagerModel.Object, 
                                                           viewInsantiator.Object);

            var eventWasRaised = false;

            albumManagerVm.PropertyChanged +=
                (sender, args) =>
                {
                    //property changed should be raised AFTER the property change.
                    albumManagerVm.Albums.Should().Be.SameInstanceAs(albumList);
                    args.PropertyName.Should().Be.EqualTo("Albums");
                    eventWasRaised = true;
                };

            albumManagerVm.SetUp(artist);
            eventWasRaised.Should().Be.True();
            albumManagerModel.VerifyAll();

        }

        [Test]
        public void edit_album_should_work()
        {
            var albumManagerModel = new Mock<IAlbumManagerModel>();
            var viewInsantiator = new Mock<IViewFactory>();
            var editAlbumViewModel = new Mock<IEditAlbumViewModel>();

            var artist = new Artist {Name = "John"};
            var album = new Album {Artist = artist};
            var albumList = new List<Album> {album};


            editAlbumViewModel.Setup(ea => ea.SetUp(album, albumManagerModel.Object));
            viewInsantiator.Setup(vi => vi.ResolveViewModel<IEditAlbumViewModel>())
                           .Returns(editAlbumViewModel.Object)
                           .AtMostOnce();

            albumManagerModel.Setup(am => am.GetAlbumsByArtist(artist))
                .Returns(albumList)
                .AtMostOnce();


            var albumManagerVm = new AlbumManagerViewModel(albumManagerModel.Object,
                                                           viewInsantiator.Object);
            albumManagerVm.SetUp(artist);

            albumManagerVm.SelectedAlbum = album;
            albumManagerVm.EditSelectedAlbumCommand.Execute(null);

            //Cannot execute edit until ends editing.
            albumManagerVm.EditSelectedAlbumCommand.CanExecute(null).Should().Be.False();


            editAlbumViewModel.VerifyAll();
            viewInsantiator.VerifyAll();
        }
    }
}