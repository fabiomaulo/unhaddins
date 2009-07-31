using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;
using ChinookMediaManager.Presenters.ModelInterfaces;
using Moq;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test
{
    [TestFixture]
    public class AlbumManagerPresenterFixture
    {
        [Test]
        public void open_view_should_show_window()
        {
            var albumMgmModel = new Mock<IAlbumManagerModel>();
            var windowsManager = new Mock<IWindowManager>();
            var editAlbumPresenter = new Mock<IEditAlbumPresenter>();

            SetupWindowsManager(windowsManager);

            var albumMgmPresenter = new AlbumManagerPresenter(albumMgmModel.Object, 
                                                                windowsManager.Object, 
                                                                editAlbumPresenter.Object);

            albumMgmPresenter.OpenView(new Artist());


            windowsManager.Verify(wm => wm.Show(albumMgmPresenter,
                                                It.IsAny<object>(),
                                                It.IsAny<Action<ISubordinate, Action>>()));
        }

        private void SetupWindowsManager(Mock<IWindowManager> windowsManager)
        {
            windowsManager.Setup(
                wm => wm.Show(It.IsAny<object>(), 
                              It.IsAny<object>(), 
                              It.IsAny<Action<ISubordinate,Action>>()))
                .AtMostOnce();
        }

        [Test]
        public void open_view_with_nulls_args_should_fail()
        {
            var albumMgmModel = new Mock<IAlbumManagerModel>();
            var windowsManager = new Mock<IWindowManager>();
            var editAlbumPresenter = new Mock<IEditAlbumPresenter>();

            var albumMgm = new AlbumManagerPresenter(albumMgmModel.Object, 
                                                    windowsManager.Object, 
                                                    editAlbumPresenter.Object);

            new Action(() => albumMgm.OpenView(null)).Should().Throw<ArgumentNullException>()
                .And.ValueOf.Message.Should().EndWith("artist");

        }
        
        [Test]
        public void can_load_data()
        {
            var albumMgmModel = new Mock<IAlbumManagerModel>();
            var windowsManager = new Mock<IWindowManager>();
            var editAlbumPresenter = new Mock<IEditAlbumPresenter>();
            var artist = new Artist {Name = "Juan"};

            SetupWindowsManager(windowsManager);
            
            albumMgmModel.Setup(am => am.GetAlbumsByArtist(artist))
                         .Returns(new List<IAlbum>())
                         .AtMostOnce();

            var albumMgm = new AlbumManagerPresenter(albumMgmModel.Object,
                                                    windowsManager.Object,
                                                    editAlbumPresenter.Object);
            
            
            albumMgm.OpenView(artist);

            albumMgm.LoadData();


            albumMgmModel.Verify(am => am.GetAlbumsByArtist(artist));

        }
        
        [Test]
        public void edit_should_open_edit_album()
        {
            var windowsManager = new Mock<IWindowManager>();
            SetupWindowsManager(windowsManager);


            var model = new Mock<IAlbumManagerModel>();
            var editPresenter = new Mock<IEditAlbumPresenter>();
            var editableAlbum = new Mock<IEditableAlbum>();

            editableAlbum.Setup(album => album.BeginEdit()).AtMostOnce();
            
            editPresenter.Setup(presenter => presenter.Setup(It.IsAny<IPresenterManager>(), 
                                                                 editableAlbum.Object, 
                                                                 model.Object));
            
            var albumMgm = new AlbumManagerPresenter(model.Object,
                                                    windowsManager.Object,
                                                    editPresenter.Object);


            albumMgm.LaunchEdit(editableAlbum.Object);

            editableAlbum.Verify(album => album.BeginEdit());
            editPresenter.Setup(eaPresenter => eaPresenter.Setup(albumMgm, 
                                                 editableAlbum.Object, 
                                                 model.Object));

            albumMgm.CurrentPresenter.Should().Be.EqualTo(editPresenter.Object);
            
        }

        [Test]
        public void can_commit_all()
        {
            var albumManagerModelMoq = new Mock<IAlbumManagerModel>();
            var windowsManager = new Mock<IWindowManager>();
            var editAlbumPresenter = new Mock<IEditAlbumPresenter>();
            albumManagerModelMoq.Setup(am => am.AceptAll()).AtMostOnce();

            IAlbumManagerPresenter albumManagerPresenter =
                new AlbumManagerPresenter(albumManagerModelMoq.Object,
                                          windowsManager.Object,
                                          editAlbumPresenter.Object);

            albumManagerPresenter.SaveAll();

            albumManagerModelMoq.VerifyAll();
        }
    }
}