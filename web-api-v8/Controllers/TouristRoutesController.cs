using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using web_api_v8.Dtos;
using web_api_v8.Services;

namespace web_api_v8.Controllers
{
    [Route("api/[controller]")] //api/touristroute
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoutes();
            if (touristRouteFromRepo == null || touristRouteFromRepo.Count() < 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRouteFromRepo);
            return Ok(touristRoutesDto);
        }

        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound("没有旅游路线");
            }
            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteFromRepo);
        }
    }
}
