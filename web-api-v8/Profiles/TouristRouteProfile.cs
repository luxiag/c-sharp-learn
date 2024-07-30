using AutoMapper;
using web_api_v8.Dtos;

using web_api_v8.Modules;
namespace web_api_v8.Profiles
{
    public class TouristRouteProfile : Profile
    {
        public TouristRouteProfile()
        {

            CreateMap<TouristRoute, TouristRouteDto>().
                ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1))
                ).ForMember(dest => dest.TravelDays, opt => opt.MapFrom(src => src.TravelDays.ToString()));

            CreateMap<TouristRouteForCreationDto, TouristRoute>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
                );

        }
    }
}
