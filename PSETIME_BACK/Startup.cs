using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PSETIME_BACK.Configurations;
using PSETIME_BACK.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK
{
    public class Startup
    {
        const String email = "https://pse-consulting.com";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // application DB context adding 
            services.AddDbContext<ApplicationDBContext>();
            services.AddBaseDAO();
            services.AddBaseServices();

            services.AddControllers();


            /// injection of swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "PSE TIME",
                        Description = "Services list of api",
                        TermsOfService = new Uri(email),
                        Contact = new OpenApiContact
                        {
                            Name = "PSE Consulting Cameroon",
                            Email = string.Empty,
                            Url = new Uri(email),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "PSE",
                            Url = new Uri(email),
                        }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Swagger configuration
            app.UseSwagger();
            // Enable middleware to serve swagger-ui(HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSE TIME");
            });
        }
    }
}
