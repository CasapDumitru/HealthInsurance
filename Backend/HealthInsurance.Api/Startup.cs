using HealthInsurance.Core.Interfaces.Specifications;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Repositories;
using HealthInsurance.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using HealthInsurance.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using AutoMapper;
using HealthInsurance.Api.Exceptions;
using HealthInsurance.Api.ActionFilters;

namespace HealthInsurance.Api
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
            services.AddSwaggerGen( options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Health Insurance API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<ValidationFilterAttribute>();

            services.AddMvc(setupAction =>
			{
				setupAction.ReturnHttpNotAcceptable = true;
				setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddAutoMapper();

            services.AddDbContext<HealthInsuranceContext>(options =>
                options.UseSqlServer(Configuration["connectionStrings:healthInsuranceConnectionString"]));

            // repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IRepository, Repository>();

            // services
            services.AddScoped<IOfficeService, OfficeService>();
			services.AddScoped<IUserService, UserService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
