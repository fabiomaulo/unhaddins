using System;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
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
            var previousPresenter = new Mock<IPresenter>();

            windowsManager.Setup(
                wm => wm.Show(It.IsAny<object>(), 
                              It.IsAny<object>(), 
                              It.IsAny<Action<ISubordinate,Action>>()))
                              .AtMostOnce();

            var albumMgmPresenter = new AlbumManagerPresenter(albumMgmModel.Object, windowsManager.Object);

            albumMgmPresenter.OpenView(previousPresenter.Object, new Artist());


            windowsManager.Verify(wm => wm.Show(albumMgmPresenter,
                                                It.IsAny<object>(),
                                                It.IsAny<Action<ISubordinate, Action>>()));
        }

        [Test]
        public void open_view_with_nulls_args_should_fail()
        {
            var albumMgmModel = new Mock<IAlbumManagerModel>();
            var windowsManager = new Mock<IWindowManager>();

            var albumMgm = new AlbumManagerPresenter(albumMgmModel.Object, windowsManager.Object);

            new Action(() => albumMgm.OpenView(null, new Artist())).Should().Throw<ArgumentNullException>()
                .And.ValueOf.Message.Should().EndWith("owner");

            var presenter = new Mock<IPresenter>();

            new Action(() => albumMgm.OpenView(presenter.Object, null)).Should().Throw<ArgumentNullException>()
                .And.ValueOf.Message.Should().EndWith("artist");
        }
        
    }
}