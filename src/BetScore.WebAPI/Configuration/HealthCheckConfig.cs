using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BetScore.WebAPI.Configuration
{
    public static class HealthConfig
    {
        public static IServiceCollection HealthCheckConfig(this IServiceCollection services, IConfiguration configuration)
        {

            var ConnectionString = configuration["BETSCORE_API_CONTEXT"];

            if (ConnectionString == null || string.IsNullOrWhiteSpace(ConnectionString.ToString()))
            {
                ConnectionString = configuration.GetConnectionString("BetScoreAPIContext");
            }

            services.AddHealthChecks()
            .AddMySql(ConnectionString, name: "CONNECTION_STRING_HEALTH")
            .AddKafka(new Confluent.Kafka.ProducerConfig { BootstrapServers = configuration["KAFKA_BOOTSTRAP_SERVERS"] }, topic: configuration["KAFKA_TOPIC_CHARACTERISTIC_EVENT"], name: "KAFKA_HEALTH"); ;

            return services;

        }

        public static IApplicationBuilder UseHealthCheckConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {

            app.UseHealthChecks("/health-check", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app;
        }

    }
}
