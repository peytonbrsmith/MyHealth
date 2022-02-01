using System.Linq;
using System.Threading.Tasks;

using myhealth.Core.Services;

using NUnit.Framework;

namespace myhealth.Core.Tests.NUnit
{
    // TODO WTS: Add appropriate unit tests.
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsChartDataAsync()
        {
            var actual = await SampleDataService.GetChartDataAsync();

            Assert.IsNotEmpty(actual);
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsContentGridDataAsync()
        {
            var actual = await SampleDataService.GetContentGridDataAsync();

            Assert.AreNotEqual(0, actual.Count());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsGridDataAsync()
        {
            var actual = await SampleDataService.GetGridDataAsync();

            Assert.AreNotEqual(0, actual.Count());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsImageGalleryDataAsync()
        {
            var actual = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            Assert.AreNotEqual(0, actual.Count());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsListDetailsDataAsync()
        {
            var actual = await SampleDataService.GetListDetailsDataAsync();

            Assert.AreNotEqual(0, actual.Count());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Test]
        public async Task EnsureSampleDataServiceReturnsTreeViewDataAsync()
        {
            var actual = await SampleDataService.GetTreeViewDataAsync();

            Assert.AreNotEqual(0, actual.Count());
        }
    }
}
