using RunpathCodingTest.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunpathCodingTest.Config
{
    public interface IWebApiClient
    {
        Task<IValueJsonResponse<T>> ExecuteAsync<T>(IWebApiAsyncQuery<T> webApiAsyncQuery);

    }
}
