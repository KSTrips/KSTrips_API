using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace KSTrips_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    IConfigurationRoot builtConfig = config.Build();
                    config.AddAzureKeyVault(builtConfig["KeyVault:Url"]
                        , builtConfig["KeyVault:ClientId"]
                        , builtConfig["KeyVault:ClientSecret"]
                        , new DefaultKeyVaultSecretManager());

                })
                .UseStartup<Startup>();

    }


}
