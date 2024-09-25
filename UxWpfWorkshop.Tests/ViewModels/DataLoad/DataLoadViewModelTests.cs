using CommunityToolkit.Mvvm.Messaging;
using Moq;
using UxWpfWorkshop.Services;
using UxWpfWorkshop.Services.DTOs;
using UxWpfWorkshop.ViewModels.DataLoad;

namespace UxWpfWorkshop.Tests.ViewModels.DataLoad
{
    public class DataLoadViewModelTests
    {
        private DataLoadViewModel target;
        private Mock<IMessenger> messengerMock;
        private Mock<IDataService> dataServiceMock;

        [SetUp]
        public void Setup()
        {
            messengerMock = new Mock<IMessenger>();
            dataServiceMock = new Mock<IDataService>();
            target = new DataLoadViewModel(messengerMock.Object, dataServiceMock.Object);
        }

        [Test]
        public void LoadDataAsyncShouldLoadDataAndSayHello()
        {
            // Arrange
            var data = new DataDto(42, "Test Name", "Test Description");

            dataServiceMock
                .Setup(x => x.GetDataAsync())
                .ReturnsAsync(data);

            // Act
            target.LoadDataCommand.Execute(null);

            // Assert
            Assert.That(target.SayHello, Is.EqualTo("Hello: " + data.Description));
        }
    }
}
