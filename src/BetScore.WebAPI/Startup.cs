using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using BetScore.Data.Repositories;
using BetScore.WebAPI.Extensions;
using BetScore.WebAPI.Configuration;
using Characteristics.WebAPI.Configuration;
using BetScore.Application.AutoMapper;

namespace BetScore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var producerConfig = new Confluent.Kafka.ProducerConfig();
            _configuration.Bind("producer", producerConfig);

            services.AddControllers();
            NewMethod(services, producerConfig);

            services.AddDbContext<Context>(options =>
                options.UseMySQL(_configuration["BETSCORE_API_CONTEXT"]));

            services.WebApiConfig();
            services.AddSwaggerConfig();
            services.ResolveDependencies();

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            services.HealthCheckConfig(_configuration);
            //services.AddElasticsearch(_configuration);

        }

        private static void NewMethod(IServiceCollection services, Confluent.Kafka.ProducerConfig producerConfig)
        {
            services.AddSingleton<Confluent.Kafka.ProducerConfig>(producerConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseHttpContext();
            //app.UseAllElasticApm(_configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();

            app.UseSwaggerConfig(provider);
            app.UseMvcConfiguration();
            app.UseHealthCheckConfig(provider);
        }
    }
}