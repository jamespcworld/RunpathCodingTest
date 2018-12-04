using Microsoft.Extensions.Options;
using RunpathCodingTest.Config;
using RunpathCodingTest.Contracts.V1;
using RunpathCodingTest.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly WebApiSettings _webApiSettings;
        public PhotoService(
            IWebApiClient webApiClient,
            IOptions<WebApiSettings> webApiSettings
            )
        {
            _webApiClient = webApiClient;
            _webApiSettings = webApiSettings.Value;
        }

        public async Task<IReadOnlyList<Photo>> GetPhotosByAlbumIdAsync(int albumId)
        {
            var photoList =await GetAllPhotosAsync();
            return photoList.Where(i=>i.AlbumId==albumId).ToList();
        }

        public async Task<IReadOnlyList<Photo>> GetAllPhotosAsync()
        {
            var result = await _webApiClient.ExecuteAsync(new GetAllPhotosAsync());
            return result.Value;
        }

    }
}
