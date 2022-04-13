using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shed.CoreKit.WebApi;
using System.Net.Http;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SACS_Microservices
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            //services.AddControllers();
            services.AddTransient<HttpClient>();
            /*services.AddWebApiEndpoints(
                new WebApiEndpoint<IAuthorizationService>(new System.Uri("http://localhost:5001")),
                new WebApiEndpoint<IDataService>(new System.Uri("http://localhost:5002")));*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            //app.UseWebApiRedirect("api/Account", new WebApiEndpoint<IAuthorizationService>(new System.Uri("http://localhost:5001")));
            //app.UseWebApiRedirect("api/v1", new WebApiEndpoint<IDataService>(new System.Uri("http://localhost:5002")));
            //app.UseWebApiRedirect("api/logs", new WebApiEndpoint<IActivityLogger>(new System.Uri("http://localhost:5003")));
        }
    }
}
