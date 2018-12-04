using RunpathCodingTest.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunpathCodingTest.Config
{
    public class WebApiClient:IWebApiClient
    {
        private readonly IWebApiConnection _webApiConnection;

        public WebApiClient(IWebApiConnection webApiConnection)
        {
            _webApiConnection = webApiConnection;
        }


        public async Task<IValueJsonResponse<T>> ExecuteAsync<T>(IWebApiAsyncQuery<T> webApiAsyncQuery)
        {
            var result = await webApiAsyncQuery.ExecuteAsync(_webApiConnection);
            return result;
        }
    }
}
