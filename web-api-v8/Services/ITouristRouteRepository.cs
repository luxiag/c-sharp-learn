using web_api_v8.Modules;

namespace web_api_v8.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string ratingOperator, int? raringValue);
        TouristRoute GetTouristRoute(Guid touristRouteId);

        bool TouristRouteExists(Guid touristRouteId);

        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);

        void AddTouristRoute(TouristRoute touristRoute);

        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutepicture);

        void DeleteTouristRoute(TouristRoute touristRoute);

        void DeleteTouristRoutePicture(TouristRoutePicture picture);

        bool Save();

    }
}
