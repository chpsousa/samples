using ConfigurationOptions.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ConfigurationOptions.Configuration
{
    public class ServiceConfiguration
    {
        private IOptions<APIConfigurations> _apiConfigurations;

        public ServiceConfiguration(IOptions<APIConfigurations> apiConfigurations)
        {
            _apiConfigurations = apiConfigurations;
        }

        public string GetConfigs()
        {
            return JsonConvert.SerializeObject(_apiConfigurations);

        }
    }
}
