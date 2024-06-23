using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Services;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        public IActionResult GerTouristRoute()
        {
            var routes = _touristRouteRepository.GetTouristRoutes();
            return Ok(routes);
        }
    }
}
