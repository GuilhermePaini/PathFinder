using PathFinder.Models;
using QuickGraph;

namespace PathFinder.Services
{
    public interface IPathFinderService
    {
        public Task<PathResponse> FindShortestPath(DroneRouteRequest droneRoute); 
    }
}
