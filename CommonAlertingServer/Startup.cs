using CommonAlertingServer.Services.Alerts.Dwd;
using CommonAlertingServer.Services.Alerts.Dwd.Interfaces;
using CommonAlertingServer.Services.Helper.Dwd;
using CommonAlertingServer.Services.Helper.Dwd.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonAlertingServer
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
            services.AddSingleton<IDwdAlertCacheService, DwdAlertCacheService>();
            services.AddHostedService(services => (DwdAlertCacheService)services.GetService<IDwdAlertCacheService>());
            services.AddSingleton<IDwdAlertService, DwdAlertService>();
            services.AddSingleton<IDwdHelperService, DwdHelperService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Common Alerting Server (CAS)",
                        Version = "v1",
                        Description = "This API enables multiple CAP services to be queried, and will return the results as JSON-formatted data. Currently, only the DWD warnings have been implemented, but more endpoints are planned soon.",
                        TermsOfService = new Uri("https://warnthingy.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Daniel Gilbert",
                            Url = new Uri("https://g5t.de")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Multiple licenses apply.",
                            Url = new Uri("https://warnthingy.com/terms")
                        }
                    });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Common Alerting Server v1");
                c.EnableFilter();
                c.EnableDeepLinking();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
