using Microsoft.Extensions.Configuration;

namespace MusalaMaster.Core.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
        }
    }
}
