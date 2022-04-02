using Microsoft.Extensions.Configuration;

namespace Tax.Processor
{
    public class Configuration
    {
        public string APIKey { get; set; }
        private string apiKey { get; set; }

        public Configuration()
        {
            InitializeConfiguration();
            APIKey = apiKey;
        }

        public void InitializeConfiguration()
        {
            IConfiguration myConfig = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            apiKey = myConfig.GetSection("APIKey").Value;
        }
    }
}

