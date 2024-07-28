using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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
        [HttpHead]
        public IActionResult GetTouristRoutes([FromQuery] string keyword, string rating)
        {
            Regex regex = new Regex(@"([A-Za-Z0-9\-]+)(\d+)");
            string operatorType = "";
            int raringValue = -1;
            Match match = regex.Match(rating);
            if (match.Success)
            {
                operatorType = match.Groups[1].Value;
                rating = match.Groups[2].Value;
            }
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoutes(keyword, operatorType, raringValue);
            if (touristRouteFromRepo == null || touristRouteFromRepo.Count() < 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRouteFromRepo);
            return Ok(touristRoutesDto);
        }

        //api/touristroutes/{touristRouteId}
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
