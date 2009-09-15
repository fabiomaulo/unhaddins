using System;
using System.Collections.Generic;
using System.Linq;
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
            var albumList = new List<Album> { new Album { Artist = artist } };

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


            //editAlbumViewModel.Setup(ea => ea.SetUp(album, albumManagerModel.Object));

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
            
            editAlbumViewModel.Verify(ea => ea.SetUp(album, albumManagerModel.Object));
            viewInsantiator.VerifyAll();
        }

        [Test]
        public void edit_new_album_should_work()
        {
            var model = new Mock<IAlbumManagerModel>();
            var viewFactory = new Mock<IViewFactory>();
            var editAlbumViewModel = new Mock<IEditAlbumViewModel>();

            var artist = new Artist();
            var album = new Album{Artist = artist};

            model.Setup(m => m.CreateNewAlbum(artist))
                 .Returns(album);

            viewFactory.Setup(vf => vf.ResolveViewModel<IEditAlbumViewModel>())
                       .Returns(editAlbumViewModel.Object)
                       .AtMostOnce();

            editAlbumViewModel.Setup(editAlbum => editAlbum.SetUp(album, model.Object))
                              .AtMostOnce();

            var albumManagerViewModel = new AlbumManagerViewModel(
                                                            model.Object, 
                                                            viewFactory.Object);

            
            albumManagerViewModel.SetUp(artist);
            albumManagerViewModel.EditNewAlbumCommand.Execute(null);
            

            model.VerifyAll();
            editAlbumViewModel.VerifyAll();

        }


        [Test]
        public void closing_tab_after_save_new_album_should_update_list()
        {
            var model = new Mock<IAlbumManagerModel>();
            var viewFactory = new Mock<IViewFactory>();
            var editAlbumViewModel = new Mock<IEditAlbumViewModel>();

            var albumManagerViewModel = new AlbumManagerViewModel(
                                                           model.Object,
                                                           viewFactory.Object);

            var artist = new Artist();
            
            var newAlbumSaved = new Album {Artist = artist}.SetId(1);

            editAlbumViewModel.SetupGet(ea => ea.Album).Returns(newAlbumSaved);

            albumManagerViewModel.SetUp(artist);
            albumManagerViewModel.AlbumEditWorkspaces.Add(editAlbumViewModel.Object);
            
            editAlbumViewModel.Raise(ea => ea.RequestClose += null, 
                                     new EventArgs());

            albumManagerViewModel.Albums.Contains(newAlbumSaved).Should().Be.True();
        }

        [Test]
        public void closing_tab_after_cancel_new_album_should_not_update_list()
        {
            var model = new Mock<IAlbumManagerModel>();
            var viewFactory = new Mock<IViewFactory>();
            var editAlbumViewModel = new Mock<IEditAlbumViewModel>();

            var albumManagerViewModel = new AlbumManagerViewModel(
                                                           model.Object,
                                                           viewFactory.Object);

            var artist = new Artist();

            var newAlbumSaved = new Album { Artist = artist }.SetId(0);

            editAlbumViewModel.SetupGet(ea => ea.Album).Returns(newAlbumSaved);

            albumManagerViewModel.SetUp(artist);
            albumManagerViewModel.AlbumEditWorkspaces.Add(editAlbumViewModel.Object);

            editAlbumViewModel.Raise(ea => ea.RequestClose += null,
                                     new EventArgs());

            albumManagerViewModel.Albums.Contains(newAlbumSaved).Should().Be.False();
        }

        [Test]
        public void closing_tab_after_editing_album_should_not_update_list()
        {
            var model = new Mock<IAlbumManagerModel>();
            var viewFactory = new Mock<IViewFactory>();
            var editAlbumViewModel = new Mock<IEditAlbumViewModel>();

            var albumManagerViewModel = new AlbumManagerViewModel(
                                                           model.Object,
                                                           viewFactory.Object);

            var artist = new Artist();
            var album = new Album { Artist = artist }.SetId(3);

            model.Setup(m => m.GetAlbumsByArtist(artist))
                 .Returns(new List<Album> {album})
                 .AtMostOnce();

            editAlbumViewModel.SetupGet(ea => ea.Album).Returns(album);

            albumManagerViewModel.SetUp(artist);
            albumManagerViewModel.AlbumEditWorkspaces.Add(editAlbumViewModel.Object);

            editAlbumViewModel.Raise(ea => ea.RequestClose += null,
                                     new EventArgs());

            albumManagerViewModel.Albums.Contains(album).Should().Be.True();
            albumManagerViewModel.Albums.Count().Should().Be.EqualTo(1);
        }


    }
}