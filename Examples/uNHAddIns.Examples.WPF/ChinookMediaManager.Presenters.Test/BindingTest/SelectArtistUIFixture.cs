using System.Windows;
using Caliburn.Testability;
using ChinookMediaManager.GUI.Views;
using ChinookMediaManager.Presenters.Interfaces;
using NUnit.Framework;

namespace ChinookMediaManager.Presenters.Test.BindingTest
{
    [TestFixture]
    public class SelectArtistUIFixture
    {
        [Test]
        public void is_data_bound_to_artists_property()
        {
            var validator = Validator.For<BrowseArtistView, IBrowseArtistPresenter>();
            var result = validator.Validate();
            result.WasBoundTo(p => p.Artists).Should().Be.True();
            result.HasErrors.Should().Be.False();
        }
    }
}