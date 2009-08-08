using Caliburn.Testability;
using ChinookMediaManager.GUI.Views;
using ChinookMediaManager.Presenters.Interfaces;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test.BindingTest
{
    [TestFixture]
    public class EditAlbumViewFixture
    {
        [Test]
        public void is_data_bound_to_album()
        {
            var validator = Validator.For<EditAlbumView, IEditAlbumPresenter>();
            var result = validator.Validate();
            result.WasBoundTo(p => p.Album.Title).Should().Be.True();
        }
    }
}