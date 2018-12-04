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
    public class AlbumService :IAlbumService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly WebApiSettings _webApiSettings;
        public AlbumService(
            IWebApiClient webApiClient,
            IOptions<WebApiSettings> webApiSettings
            )
        {
            _webApiClient = webApiClient;
            _webApiSettings = webApiSettings.Value;
        }

        public async Task<IReadOnlyList<Album>> GetAlbumsByUserIdAsync(int userId)
        {
            var albumList = await GetAllAlbumsAsync();
            return albumList.Where(i=>i.UserId==userId).ToList();
        }

        public async Task<IReadOnlyList<Album>> GetAllAlbumsAsync()
        {
            var result = await _webApiClient.ExecuteAsync(new GetAllAlbumsAsync());
            return result.Value;
        }

    }
}
