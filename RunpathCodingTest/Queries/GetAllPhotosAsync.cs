using RunpathCodingTest.Config;
using RunpathCodingTest.Contracts;
using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Queries
{
    public class GetAllPhotosAsync : IWebApiAsyncQuery<IReadOnlyList<Photo>>
    {
        public async Task<IValueJsonResponse<IReadOnlyList<Photo>>> ExecuteAsync(IWebApiConnection webApiConnection)
        {
            return await webApiConnection.GetAsync<IReadOnlyList<Photo>>(webApiConnection.WebApiSettings.PhotoEndpoints.GetAllPhotos);
        }
    }
}
