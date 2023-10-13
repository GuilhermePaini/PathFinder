using QuickGraph;
using QuickGraph.Algorithms;
using System.Text;

namespace PathFinder
{
    public class WeightedGraph
    {
        public AdjacencyGraph<string, Edge<string>> Graph { get; set; }
        public Dictionary<Edge<string>, double> EdgeWeights { get; set; }

        public WeightedGraph(AdjacencyGraph<string, Edge<string>> graph, Dictionary<Edge<string>, double> edgeWeights)
        {
            Graph = graph;
            EdgeWeights = edgeWeights;
        }

        public List<Edge<string>> Dijkstra(string start, string end)
        {
            var shortestPath = Graph.ShortestPathsDijkstra(GetEdgeWeight, start);
            var path = new List<Edge<string>>();

            if (shortestPath(end, out IEnumerable<Edge<string>> pathEdges))
                path.AddRange(pathEdges);

            return path;
        }

        public double GetEdgeWeight(Edge<string> edge)
            => EdgeWeights.TryGetValue(edge, out double weight) ? weight : double.MaxValue;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var edge in Graph.Edges)
                stringBuilder.AppendLine($"Edge: {edge.Source} -> {edge.Target}, Weight: {EdgeWeights[edge]}\n");

            return stringBuilder.ToString();
        }
    }
}