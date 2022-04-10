using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetTest.API.Filters;
using TargetTest.API.Middleware;
using TargetTest.Application.Services.Implemetations;
using TargetTest.Application.Services.Interfaces;
using TargetTest.Application.Validators;
using TargetTest.Core.Repositories;
using TargetTest.Infrastructe.Persistence;
using TargetTest.Infrastructure.Persistence.Repositories;

namespace TargetTest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CriacaoClienteInputModelValidator>());

            var connectionString = Configuration.GetConnectionString("TargetInvestimentoDb");
            services.AddDbContext<TargetDbContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<IClienteService, ClienteService>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPlanoRepository, PlanoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TargetTest.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TargetTest.API v1"));
            }

            app.UseMiddleware<ApiKeyMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
