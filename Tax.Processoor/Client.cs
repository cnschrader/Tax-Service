using System.Net.Http.Headers;

namespace Tax.Processor
{
    public static class Client
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            Configuration config = new Configuration();

            ApiClient.DefaultRequestHeaders.Add("Authorization", $"Token token={config.APIKey}");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

