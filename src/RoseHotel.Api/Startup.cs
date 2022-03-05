using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoseHotel.Infrastructure;
using RoseHotel.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RoseHotel.Infrastructure.DAL;

namespace RoseHotel.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiName;
        private readonly string _apiVersion;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiName = _configuration[$"api:{nameof(ApiOptions.Name)}"];
            _apiVersion = _configuration[$"api:{nameof(ApiOptions.Version)}"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(_configuration);
            var connectionString = _configuration.GetSection("database").Value;

           // services.AddDbContext<RoseHotelDbContext>(x => x.UseNpgsql(connectionString));
            services.AddControllers();
            //services.AddSwaggerGen(swagger =>
            //{
            //    swagger.EnableAnnotations();
            //    swagger.CustomSchemaIds(x => x.FullName);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

           // app.UseLogging();
            //app.UseErrorHandling();
          //  app.UseSwagger();
          //  app.UseSwaggerUI();
            //app.UseReDoc(reDoc =>
            //{
            //    reDoc.RoutePrefix = "docs";
            //   // reDoc.SpecUrl($"/swagger/{_apiVersion}/swagger.json");
            //    reDoc.SpecUrl($"/swagger/{_apiVersion}/swagger.json");
            //});
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    //await context.Response.WriteAsync($"{_apiName} {_apiVersion}");
                //});
            });
        }
    }
}
