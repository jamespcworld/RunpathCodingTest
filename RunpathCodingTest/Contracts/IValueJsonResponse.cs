using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Contracts
{
    public interface IValueJsonResponse<T> : IVoidJsonResponse
    {
        T Value { get; }
    }

}
