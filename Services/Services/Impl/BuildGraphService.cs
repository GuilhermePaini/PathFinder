using QuickGraph;

namespace PathFinder.Services.Impl
{
    public class BuildGraphService : IBuildGraphService
    {
        private readonly IBuildApiDataService _buildApiDataService;
        private readonly Lazy<Task<WeightedGraph>> _weightedGraph;

        public BuildGraphService(IBuildApiDataService buildApiDataService)
        {
            _buildApiDataService = buildApiDataService;
            _weightedGraph = new Lazy<Task<WeightedGraph>>(BuildWeightedGraphAsync());
        }

        public async Task<WeightedGraph> GetWeightedGraphAsync() => await _weightedGraph.Value;

        public async Task<WeightedGraph> BuildWeightedGraphAsync()
        {
            var apiDataDictionary = await _buildApiDataService.GetDataDictionary();

            var graph = new AdjacencyGraph<string, Edge<string>>();
            var edgeWeights = new Dictionary<Edge<string>, double>();

            foreach (var outerKey in apiDataDictionary.Keys)
            {
                graph.AddVertex(outerKey);

                foreach (var innerKey in apiDataDictionary[outerKey].Keys)
                {
                    var edge = new Edge<string>(outerKey, innerKey);
                    graph.AddEdge(edge);

                    var weight = apiDataDictionary[outerKey][innerKey];
                    edgeWeights[edge] = weight;
                }
            }

            return new WeightedGraph(graph, edgeWeights);
        }
    }
}
