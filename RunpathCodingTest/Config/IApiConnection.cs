using RunpathCodingTest.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RunpathCodingTest.Config
{
    public interface IApiConnection
    {
        double TimeoutInSeconds { get; set; }
        Task<IValueJsonResponse<T>> GetAsync<T>(string url, params object[] parameters);
    }
}
