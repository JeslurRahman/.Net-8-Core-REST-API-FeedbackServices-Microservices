using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FeedbackService.Api
{
    public class RemoteHealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RemoteHealthCheck(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync("https://api.ipify.org");
                if (response.IsSuccessStatusCode)
                {
                    return HealthCheckResult.Healthy($"Remote endpoints is healthy.");
                }

                return HealthCheckResult.Unhealthy("Remote endpoint is unhealthy");
            }
        }
    }
}