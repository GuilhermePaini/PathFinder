using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PathFinder.Models;
using PathFinder.Services;

namespace AmazoniaServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PathFinderController : ControllerBase
    {
        private readonly ILogger<PathFinderController> _logger;
        private readonly IPathFinderService _pathFinderService;

        public PathFinderController(ILogger<PathFinderController> logger, IPathFinderService pathFinderService)
        {
            _logger = logger;
            _pathFinderService = pathFinderService;
        }

        [HttpGet("{startingPosition}/{objectPosition}/{deliveryPoint}")]
        public async Task<IActionResult> Get(string startingPosition, string objectPosition, string deliveryPoint) 
        {
            var droneRoute = new DroneRouteRequest(startingPosition, objectPosition, deliveryPoint);
            try
            {
                _logger.LogInformation("Request received: {request}", JsonConvert.SerializeObject(droneRoute));
                return Ok(await _pathFinderService.FindShortestPath(droneRoute));
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}