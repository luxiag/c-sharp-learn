using Microsoft.AspNetCore.Mvc;
using web_api_v8.Services;

namespace web_api_v8.Controllers
{
    [Route("api/[controller]")] //api/touristroute
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoutes();
            if (touristRouteFromRepo == null || touristRouteFromRepo.Count() < 0)
            {
                return NotFound("没有旅游路线");
            }
            return Ok(touristRouteFromRepo);
        }

        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound("没有旅游路线");
            }
            return Ok(touristRouteFromRepo);
        }
    }
}
