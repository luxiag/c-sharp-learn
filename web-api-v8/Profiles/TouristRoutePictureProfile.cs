using AutoMapper;
using web_api_v8.Dtos;
using web_api_v8.Modules;

namespace web_api_v8.Profiles
{
    public class TouristRoutePictureProfile : Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
            CreateMap<TouristRoutePictureForCreationDto, TouristRoutePicture>();
        }
    }
}
