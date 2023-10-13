using QuickGraph;

namespace PathFinder.Models
{
    public class PathResponse
    {
        public PathResponse(List<Edge<string>> routeSteps, double secondsElapsed)
        {
            RouteSteps = routeSteps;
            SecondstToTraverseRoute = secondsElapsed;
        }

        public List<Edge<string>> RouteSteps { get; set; }
        public double SecondstToTraverseRoute { get; set; }
    }
}
