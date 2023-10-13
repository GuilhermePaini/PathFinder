using Newtonsoft.Json;

namespace PathFinder.Services.Impl
{
    public class BuildApiDataService : IBuildApiDataService
    {
        private readonly Lazy<Task<string>> _serviceResponse;
        private readonly IConfiguration _configuration;

        public BuildApiDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceResponse = new Lazy<Task<string>>(FetchApiData);
        }

        public async Task<string> GetServiceResponseAsync() => await _serviceResponse.Value;

        public async Task<string> FetchApiData()
        {
            using var httpClient = new HttpClient();

            var result = await httpClient.GetAsync(_configuration["AmazoniaWebServiceApiLink"]);

            if (!result.IsSuccessStatusCode)
                throw new HttpRequestException("Não foi possível consultar a API", null, result.StatusCode);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<Dictionary<string, Dictionary<string, double>>> GetDataDictionary()
        {
            var serviceResponse = await GetServiceResponseAsync();
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, double>>>(serviceResponse);
        }
    }
}
