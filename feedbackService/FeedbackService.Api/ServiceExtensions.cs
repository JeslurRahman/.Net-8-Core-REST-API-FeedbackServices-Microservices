using FeedbackService.Api.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FeedbackService.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureHealthChecks(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration["ConnectionStrings:Feedback"], healthQuery: "select 1", name: "SQL servere", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" })
                .AddCheck<RemoteHealthCheck>("Remote endpoints Health Check", failureStatus: HealthStatus.Unhealthy)
                .AddCheck<MemoryHealthCheck>($"Feedback Service Memory Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback Service" })
                .AddUrlGroup(new Uri("https://localhost:44333/api/v1/heartbeats/ping"), name: "base URL", failureStatus: HealthStatus.Unhealthy);

            //services.AddHealthChecksUI();
            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                opt.SetApiMaxActiveRequests(1); //api requests concurrency    
                opt.AddHealthCheckEndpoint("feedback api", "/api/health"); //map health check api    

            })
                .AddInMemoryStorage();
        }
    }
}
