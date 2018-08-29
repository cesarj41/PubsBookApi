using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaribeMediaApi.Data;
using CaribeMediaApi.Interfaces;
using CaribeMediaApi.Middlewares;
using CaribeMediaApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CaribeMediaApi
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
            services.AddDbContext<PubsContext>(opts => opts.UseSqlServer(Configuration["PubsDb:ConnectionString"]));
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddSwaggerGen(options => options.SwaggerDoc(
                "v1", new Info { Title = "Caribe Media API", Version = "v1"}
            ));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<GlobalErrorHandling>();
            app.UseStaticFiles();
            if (env.IsProduction())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint(
                "/swagger/v1/swagger.json", "Caribe Media API V1"
            ));

            app.UseMvc();
        }
    }
}
