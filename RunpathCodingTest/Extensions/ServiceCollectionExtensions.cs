using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RunpathCodingTest.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebApiSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var webApiSettings = provider.GetService<IOptions<WebApiSettings>>().Value;
            services.Add(ServiceDescriptor.Singleton<IOptions<WebApiSettings>>(new OptionsWrapper<WebApiSettings>(webApiSettings)));
            return services;
        }
    }
}
