using Caliburn.Testability;
using ChinookMediaManager.Domain;
using ChinookMediaManager.GUI.Views;
using ChinookMediaManager.Presenters.Interfaces;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test.BindingTest
{
    [TestFixture]
    public class AlbumManagerViewFixture
    {
        [Test]
        public void is_data_bound_to_albums_property()
        {
            var validator = Validator.For<AlbumManagerView, IAlbumManagerPresenter>();
            var result = validator.Validate();
            result.WasBoundTo(p => p.Albums).Should().Be.True();
        }
    }
}