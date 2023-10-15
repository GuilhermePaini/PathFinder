using QuickGraph;

namespace PathFinder.Services
{
    public interface IBuildGraphService
    {
        public Task<WeightedGraph> GetWeightedGraphAsync();
    }
}
