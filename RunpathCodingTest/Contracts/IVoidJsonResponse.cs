using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Contracts
{
    public interface IVoidJsonResponse
    {
        bool Failed { get; }
        bool Succeeded { get; }
        ICollection<ErrorResponse> ValidationErrors { get; }
        void DeserialiseResponse(System.Net.Http.HttpResponseMessage response, string responseString);
    }

}
