using Microsoft.AspNetCore.Mvc;

namespace AmazoniaServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PathFinderController : ControllerBase
    {
        private readonly ILogger<PathFinderController> _logger;

        public PathFinderController(ILogger<PathFinderController> logger)
            => _logger = logger;

        [HttpGet]
        public IActionResult Get() => Ok();
    }
}