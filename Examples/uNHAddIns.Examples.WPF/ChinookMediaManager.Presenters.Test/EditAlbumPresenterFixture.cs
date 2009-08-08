using System;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;
using Moq;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test
{
    [TestFixture]
    public class EditAlbumPresenterFixture
    {
        [Test]
        public void setup_should_notify_album_change()
        {
            IEditAlbumPresenter editAlbumPresenter = new EditAlbumPresenter();
            var owner = new Mock<IPresenterManager>();
            var albumModel = new Mock<IAlbumManagerModel>();

            bool eventWasRaised = false;
            editAlbumPresenter.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals("Album"))
                    eventWasRaised = true;
            };

            editAlbumPresenter.Setup(owner.Object, new Album(), albumModel.Object);
            
            eventWasRaised.Should().Be.True();
        }

        //[Test]
        //public void can_cancel_edit()
        //{
        //    IEditAlbumPresenter editAlbumPresenter = new EditAlbumPresenter();
        //    var owner = new Mock<IPresenterManager>();
        //    var album = new Album();
        //    var albumModel = new Mock<IAlbumManagerModel>();

        //    owner.Setup(o => o.Shutdown(It.IsAny<IPresenter>(), It.IsAny<Action<bool>>()))
        //         .AtMostOnce();

            
        //    editAlbumPresenter.Setup(owner.Object, album, albumModel.Object);
            
        //    editAlbumPresenter.Cancel();
            
            
        //    album.VerifyAll();
        //    owner.Verify(o=>o.Shutdown(editAlbumPresenter, It.IsAny<Action<Boolean>>()));
      
        //}

        //[Test]
        //public void can_acept_album()
        //{
        //    IEditAlbumPresenter editAlbumPresenter = new EditAlbumPresenter();

        //    var owner = new Mock<IPresenterManager>();
        //    var albumModel = new Mock<IAlbumManagerModel>();
        //    var editableAlbum = new Mock<IEditableAlbum>();

        //    editableAlbum.Setup(album => album.EndEdit())
        //                 .AtMostOnce();
            
        //    //albumModel.Setup(am => am.Save(It.IsAny<IAlbum>()));

        //    owner.Setup(o => o.Shutdown(It.IsAny<IPresenter>(), It.IsAny<Action<bool>>()))
        //        .AtMostOnce();


        //    editAlbumPresenter.Setup(owner.Object, 
        //                                editableAlbum.Object, 
        //                                albumModel.Object);

        //    editAlbumPresenter.Save();

        //    owner.Verify(o => o.Shutdown(editAlbumPresenter, It.IsAny<Action<Boolean>>()));
        //    //albumModel.Verify(am => am.Save(editableAlbum.Object));
        //    editableAlbum.Verify(ea=>ea.EndEdit());

        //}

        //[Test]
        //public void can_add_new_track()
        //{
        //    IEditAlbumPresenter editAlbumPresenter = new EditAlbumPresenter();

        //    var owner = new Mock<IPresenterManager>();
        //    var albumModel = new Mock<IAlbumManagerModel>();
        //    var editableAlbum = new Mock<IEditableAlbum>();

        //    editableAlbum.Setup(album => album.AddTrack(It.IsAny<Track>()))
        //                 .Callback((Track track) => track.Name.Should().Be.EqualTo("New track"));


        //    editAlbumPresenter.Setup(
        //        owner.Object, 
        //        editableAlbum.Object, 
        //        albumModel.Object);

        //    editAlbumPresenter.AddNewEmptyTrack();

        //    editableAlbum.Verify(ea => ea.AddTrack(It.IsAny<Track>()));
        //}

        //[Test]
        //public void can_remove_track()
        //{
        //    IEditAlbumPresenter editAlbumPresenter = new EditAlbumPresenter();

        //    var owner = new Mock<IPresenterManager>();
        //    var albumModel = new Mock<IAlbumManagerModel>();
        //    var editableAlbum = new Mock<IEditableAlbum>();
        //    var track = new Track();

        //    editableAlbum.Setup(album => album.RemoveTrack(track));


        //    editAlbumPresenter.Setup(
        //        owner.Object, editableAlbum.Object, albumModel.Object);

        //    editAlbumPresenter.RemoveSelectedTrack(track);

        //    editableAlbum.Verify(ea => ea.RemoveTrack(track));
        //}

    }
}