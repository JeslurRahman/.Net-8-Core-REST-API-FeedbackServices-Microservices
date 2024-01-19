using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FeedbackService.Core.Interfaces.Repositories;
using FeedbackService.Core.Interfaces.Services;
using FeedbackService.Core.Services;
using FeedbackService.Infrastructure.Context;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.Azure.KeyVault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;

namespace FeedbackService.Api
{
    //Used for Dependancy Injection separately without collaps with Program.cs
    public static class DependancyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            //Dependancy Injection
            /*
            services.AddDbContext<FeedbackDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("InMemory");

            });
            */

            //If you need to use the local environment change the IsProduction() into IsDevelopment()
            //and go to the KeyVaultCache.cs file, there also change into reverse
            //In the production environment, you are using the connection string directly from the local configuration. 
            if (environment.IsProduction())
            {
                services.AddDbContext<FeedbackDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("Feedback"));
                });

            }

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbacksService>();
            services.AddHttpClient(); //Need to add for Health Check of RemoteHealthCheck

            return services;
        }

    }
}
