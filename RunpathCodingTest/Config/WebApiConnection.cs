using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunpathCodingTest.Config
{
    public class WebApiConnection : ApiConnection, IWebApiConnection
    {
        public WebApiSettings WebApiSettings { get; private set; }

        public WebApiConnection(
                   IOptions<WebApiSettings> webApiSettings)
        {
            this.BaseUrl = webApiSettings?.Value?.BaseWebApiUrl;
            this.WebApiSettings = webApiSettings?.Value;
            this.TimeoutInSeconds = webApiSettings?.Value?.TimeoutInSeconds ?? 60;
        }

    }
}
