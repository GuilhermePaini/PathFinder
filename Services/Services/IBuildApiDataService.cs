namespace PathFinder.Services
{
    public interface IBuildApiDataService
    {
        public Task<string> FetchApiData();
        public Task<Dictionary<string, Dictionary<string, double>>> GetDataDictionary();
    }
}
