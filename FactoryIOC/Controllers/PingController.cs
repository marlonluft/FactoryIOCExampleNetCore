using FactoryIOC.Enumerator;
using FactoryIOC.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FactoryIOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        private readonly IShapeCalculationService _shapeCalculationService;

        public PingController(ILogger<PingController> logger, IShapeCalculationService shapeCalculationService)
        {
            _logger = logger;
            _shapeCalculationService = shapeCalculationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cubeDetails = _shapeCalculationService.CalculateShapeMeasurements(EShape.Cube);
            var sphereDetails = _shapeCalculationService.CalculateShapeMeasurements(EShape.Sphere);

            return Ok(new
            {
                Cube = cubeDetails,
                Sphere = sphereDetails
            });
        }
    }
}
