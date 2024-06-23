﻿using web_api.Modules;

namespace web_api.Services
{
    public class MockTourisRouteRepository: ITouristRouteRepository
    {
        private List<TouristRoute> _routes;
        public MockTourisRouteRepository() { 
            if( _routes == null )
            {
                InitializeTouristRoute();
            }
        }

        private void InitializeTouristRoute()
        {
            _routes = new List<TouristRoute>
            {
                new TouristRoute
                {
                    Id = Guid.NewGuid(),
                    Title = "Test",
                    Description = "Test",
                    OriginalPrice = 1,
                    Features = "Test",
                    Fees = "Test",
                    Notes = "Test"
                }
            };

        }

        public IEnumerable<TouristRoute> GetTouristRoutes() {
            return _routes;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            //linq
            return _routes.FirstOrDefault(n => n.Id == touristRouteId);

        }

        public TouristRoute GetRouristRoute(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }
    }
}
