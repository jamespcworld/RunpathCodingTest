using RunpathCodingTest.Config;
using RunpathCodingTest.Contracts;
using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Queries
{
    public class GetAllAlbumsAsync : IWebApiAsyncQuery<IReadOnlyList<Album>>
    {
        public async Task<IValueJsonResponse<IReadOnlyList<Album>>> ExecuteAsync(IWebApiConnection webApiConnection)
        {
            return await webApiConnection.GetAsync<IReadOnlyList<Album>>(webApiConnection.WebApiSettings.AlbumEndpoints.GetAllAlbums);
        }
    }
}
