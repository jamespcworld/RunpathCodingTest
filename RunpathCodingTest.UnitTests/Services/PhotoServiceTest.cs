using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunpathCodingTest.Config;
using RunpathCodingTest.Contracts;
using RunpathCodingTest.Contracts.V1;
using RunpathCodingTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunpathCodingTest.UnitTest.Services
{
    [TestClass]
    public class PhotoServiceTest
    {
        private Mock<IWebApiClient> _mockWebApiClient;
        private Mock<IOptions<WebApiSettings>> _mockWebApiSettings;


        public PhotoServiceTest()
        {
            _mockWebApiClient = new Mock<IWebApiClient>();
            _mockWebApiSettings = new Mock<IOptions<WebApiSettings>>();
        }

        [TestMethod]
        public async Task GetAllPhotosAsync_ReturnsAllPhotos()
        {
            //Arrange

            var _mockPhotoList = new Mock<IValueJsonResponse<IReadOnlyList<Photo>>>();

            _mockPhotoList.Setup(x => x.Value).Returns(new List<Photo> {
                 new Photo{ Id=1, AlbumId=1},
                 new Photo{ Id=2, AlbumId=1}
            });

            _mockWebApiClient
               .Setup(x => x.ExecuteAsync(It.IsAny<IWebApiAsyncQuery<IReadOnlyList<Photo>>>()))
               .Returns(Task.FromResult(_mockPhotoList.Object));

            var photoService = new PhotoService(
                _mockWebApiClient.Object,
                _mockWebApiSettings.Object
                );

            //Act
            var photoList = await photoService.GetAllPhotosAsync();

            //Assert
            Assert.AreEqual(photoList, _mockPhotoList.Object.Value);
        }


        [TestMethod]
        public async Task GetPhotosByAlbumIdAsync_WithValidAlbumId_ReturnsFilteredPhotoList()
        {
            //Arrange

            var _mockPhotoList = new Mock<IValueJsonResponse<IReadOnlyList<Photo>>>();

            _mockPhotoList.Setup(x => x.Value).Returns(new List<Photo> {
                 new Photo{ Id=1, AlbumId=1},
                 new Photo{ Id=2, AlbumId=1},
                 new Photo{ Id=3, AlbumId=2},
                 new Photo{ Id=4, AlbumId=2}
            });

            _mockWebApiClient
               .Setup(x => x.ExecuteAsync(It.IsAny<IWebApiAsyncQuery<IReadOnlyList<Photo>>>()))
               .Returns(Task.FromResult(_mockPhotoList.Object));

            var photoService = new PhotoService(
                _mockWebApiClient.Object,
                _mockWebApiSettings.Object
                );

            //Act
            var photoList = await photoService.GetPhotosByAlbumIdAsync(1);

            //Assert
            Assert.AreEqual(photoList.Count, 2);
            Assert.AreEqual(photoList[0].Id, 1);
            Assert.AreEqual(photoList[1].Id, 2);
        }



    }
}
