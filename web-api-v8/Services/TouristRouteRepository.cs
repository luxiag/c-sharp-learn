using Microsoft.EntityFrameworkCore;
using web_api_v8.Database;
using web_api_v8.Modules;

namespace web_api_v8.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;
        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault(n => n.Id == touristRouteId);
        }
        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string ratingOperator, int? ratingValue)
        {
            IQueryable<TouristRoute> result = _context
                .TouristRoutes
                .Include(t => t.TouristRoutePictures);

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                result.Where(t => t.Title.Contains(keyword));
            }

            if (ratingValue >= 0)
            {
                switch (ratingOperator)
                {
                    case "largerThan":
                        result = result.Where(t => t.Rating >= ratingValue);
                        break;
                    case "lessThan":
                        result = result.Where(t => t.Rating <= ratingValue); break;
                    case "euqalTo":
                    default:
                        result = result.Where(t => t.Rating == ratingValue); break;
                }
            }
            return result.ToList();
            //return _context.TouristRoutes.Include(t => t.TouristRoutePictures);
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            return _context.TouristRoutes.Any(t => t.Id == touristRouteId);
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutesPictures.Where(p => p.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return _context.TouristRoutesPictures.Where(p => p.Id == pictureId).FirstOrDefault();
        }
        public void AddTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
            {
                throw new ArgumentNullException(nameof(touristRoute));
            }
            _context.TouristRoutes.Add(touristRoute);
        }
        public void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture)
        {
            if ((touristRouteId == Guid.Empty))
            {
                throw new ArgumentOutOfRangeException(nameof(touristRouteId));
            }
            if (touristRoutePicture == null)
            {
                throw new ArgumentOutOfRangeException(nameof(touristRoutePicture));
            }
            touristRoutePicture.TouristRouteId = touristRouteId;
            _context.TouristRoutesPictures.Add(touristRoutePicture);
        }
        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
