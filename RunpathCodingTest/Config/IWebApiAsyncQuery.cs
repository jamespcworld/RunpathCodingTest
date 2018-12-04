using RunpathCodingTest.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunpathCodingTest.Config
{
    public interface IWebApiAsyncQuery<T>
    {
        Task<IValueJsonResponse<T>> ExecuteAsync(IWebApiConnection webApiConnection);
    }
}
