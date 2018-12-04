using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunpathCodingTest.Config;
using RunpathCodingTest.Extensions;

namespace RunpathCodingTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ConfigureOptions(services);
            ConfigureDI(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "Album",
                    "Album/User/{userId}",                           
                    new { controller = "Album", action = "Index", userId="" } 
                );

                routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" });
            });
        }

        private void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<WebApiSettings>(Configuration.GetSection(nameof(WebApiSettings)));
            services.AddWebApiSettings();
        }
        private void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<Services.IAlbumService, Services.AlbumService>();
            services.AddScoped<Services.IPhotoService, Services.PhotoService>();

            services.AddScoped<IWebApiClient, WebApiClient>();
            services.AddScoped<IWebApiConnection, WebApiConnection>();
        }
    }
}
