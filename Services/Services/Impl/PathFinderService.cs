using PathFinder.Models;

namespace PathFinder.Services.Impl
{
    public class PathFinderService : IPathFinderService
    {
        private readonly IBuildGraphService _buildGraphService;

        public PathFinderService(IBuildGraphService buildGraphService)
        {
            _buildGraphService = buildGraphService;
        }

        public async Task<PathResponse> FindShortestPath(DroneRouteRequest droneRoute)
        {
            var graph = await _buildGraphService.GetWeightedGraphAsync();
            var startingPointToObject = graph.Dijkstra(droneRoute.StartingPosition, droneRoute.ObjectPosition);
            var objectToDeliveryPoint = graph.Dijkstra(droneRoute.ObjectPosition, droneRoute.DeliveryPoint);
            var shortestPath = startingPointToObject.Concat(objectToDeliveryPoint).ToList();
            var secondsToTraverseRoute = shortestPath.Sum(x => graph.EdgeWeights[x]);

            return new PathResponse(shortestPath, secondsToTraverseRoute);
        }
    }
}
