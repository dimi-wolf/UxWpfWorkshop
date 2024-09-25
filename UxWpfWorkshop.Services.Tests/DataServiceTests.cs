using UxWpfWorkshop.Services.Impl;

namespace UxWpfWorkshop.Services.Tests
{
    public class DataServiceTests
    {
        private DataService target;

        [SetUp]
        public void Setup()
        {
            target = new DataService();
        }

        [Test]
        public async Task GetDataAsyncShouldReturnData()
        {
            // Act
            var data = await target.GetDataAsync();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null);
                Assert.That(data.Id, Is.EqualTo(1));
                Assert.That(data.Name, Is.EqualTo("Some Data"));
                Assert.That(data.Description, Is.EqualTo("Here is your data."));
            });
        }
    }
}