using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FeedbackService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Api
{
    public static class KeyVaultCache
    {
        public static IServiceCollection ConfigureKeyVaultCache(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {

            #region AzureKeyVault
            //If you need to use the local environment change the IsDevelopment() into IsProduction()
            //and go to the DependencyInjection.cs file, there also change into reverse
            //In the development environment, you are using Azure Key Vault to store the production-level connection string.
            if (environment.IsDevelopment())
            {
                var KeyVaultURI = configuration.GetSection("KeyVault:KeyVaultURL");
                var KeyVaultClientId = configuration.GetSection("KeyVault:ClientId");
                var KeyVaultClientSecret = configuration.GetSection("KeyVault:ClientSecret");
                var KeyVaultDirectoryId = configuration.GetSection("KeyVault:DirectoryId");

                var credential = new ClientSecretCredential(KeyVaultDirectoryId.Value!.ToString(), KeyVaultClientId.Value!.ToString(), KeyVaultClientSecret.Value!.ToString());
                var secretClient = new SecretClient(new Uri(KeyVaultURI.Value!.ToString()), credential);

                var connectionStringSecret = secretClient.GetSecret("ProdConnection");

                services.AddDbContext<FeedbackDbContext>(options =>
                {
                    options.UseSqlServer(connectionStringSecret.Value.Value.ToString());
                });
            }
            #endregion
            return services;

        }
    }
}
