using System;
using System.Collections.Generic;
using System.Text;

namespace RunpathCodingTest.Config
{
    public interface IWebApiConnection : IApiConnection
    {
        WebApiSettings WebApiSettings { get; }
    }
}
