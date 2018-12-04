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
    public class AlbumServiceTest
    {
        private Mock<IWebApiClient> _mockWebApiClient;
        private Mock<IOptions<WebApiSettings>> _mockWebApiSettings;


        public AlbumServiceTest()
        {
            _mockWebApiClient = new Mock<IWebApiClient>();
            _mockWebApiSettings = new Mock<IOptions<WebApiSettings>>();
        }

        [TestMethod]
        public async Task GetAllAlbumsAsync_ReturnsAllAlbums()
        {
            //Arrange

            var _mockAlbumList = new Mock<IValueJsonResponse<IReadOnlyList<Album>>>();

            _mockAlbumList.Setup(x => x.Value).Returns(new List<Album> {
                 new Album{ Id=1, UserId=2},
                 new Album{ Id=2, UserId=3}
            });

            _mockWebApiClient
               .Setup(x => x.ExecuteAsync(It.IsAny<IWebApiAsyncQuery<IReadOnlyList<Album>>>()))
               .Returns(Task.FromResult(_mockAlbumList.Object));

            var albumService = new AlbumService(
                _mockWebApiClient.Object,
                _mockWebApiSettings.Object
                );

            //Act
            var albumList = await albumService.GetAllAlbumsAsync();

            //Assert
            Assert.AreEqual(albumList, _mockAlbumList.Object.Value);
        }


        [TestMethod]
        public async Task GetAlbumsByUserIdAsync_WithValidUserId_ReturnsUserAlbumList()
        {
            //Arrange

            var _mockAlbumList = new Mock<IValueJsonResponse<IReadOnlyList<Album>>>();

            _mockAlbumList.Setup(x => x.Value).Returns(new List<Album> {
                 new Album{ Id=1, UserId=1},
                 new Album{ Id=2, UserId=1},
                 new Album{ Id=3, UserId=2},
                 new Album{ Id=4, UserId=2}
            });

            _mockWebApiClient
               .Setup(x => x.ExecuteAsync(It.IsAny<IWebApiAsyncQuery<IReadOnlyList<Album>>>()))
               .Returns(Task.FromResult(_mockAlbumList.Object));

            var albumService = new AlbumService(
                _mockWebApiClient.Object,
                _mockWebApiSettings.Object
                );

            //Act
            var photoList = await albumService.GetAlbumsByUserIdAsync(2);

            //Assert
            Assert.AreEqual(photoList.Count, 2);
            Assert.AreEqual(photoList[0].Id, 3);
            Assert.AreEqual(photoList[1].Id, 4);
        }



    }
}
