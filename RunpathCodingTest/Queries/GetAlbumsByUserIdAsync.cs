using RunpathCodingTest.Config;
using RunpathCodingTest.Contracts;
using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Queries
{
    public class GetAlbumsByUserIdAsync : IWebApiAsyncQuery<IReadOnlyList<Album>>
    {

        private readonly int _userId;
        public GetAlbumsByUserIdAsync(int userId)
        {
            _userId = userId;
        }

        public async Task<IValueJsonResponse<IReadOnlyList<Album>>> ExecuteAsync(IWebApiConnection webApiConnection)
        {
            return await webApiConnection.GetAsync<IReadOnlyList<Album>>(webApiConnection.WebApiSettings.AlbumEndpoints.GetAlbumsByUserId, _userId);
        }
    }
}
