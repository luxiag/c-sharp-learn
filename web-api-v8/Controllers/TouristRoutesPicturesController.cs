using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using web_api_v8.Dtos;
using web_api_v8.Modules;
using web_api_v8.Services;

namespace web_api_v8.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutesPicturesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        private IMapper _mapper;

        public TouristRoutesPicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var picturesFromRepo = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound("照片不存在");
            }
            return Ok(_mapper.Map<IEnumerable<TouristRouteRepository>>(picturesFromRepo));
        }

        [HttpGet("{pictureId}", Name = "GetPicture")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var pictureFromRepo = _touristRouteRepository.GetPicture(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("相片不存在");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
        }

        [HttpPost]
        public IActionResult CreateTouristRoutePicture(
            [FromBody] Guid touristRouteId,
            [FromBody] TouristRoutePictureForCreationDto touristRoutePictureForCreationDto
            )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }
            var pictureModel = _mapper.Map<TouristRoutePicture>(touristRoutePictureForCreationDto);
            _touristRouteRepository.AddTouristRoutePicture(touristRouteId, pictureModel);
            _touristRouteRepository.Save();
            var pictureToReturn = _mapper.Map<TouristRoutePictureDto>(pictureModel);
            return CreatedAtRoute("GetPicture", new
            {
                touristRouteId = pictureModel.TouristRouteId,
                pictureId = pictureModel.Id
            },
            pictureToReturn
            );
        }
    }
}
