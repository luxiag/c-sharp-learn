using Microsoft.EntityFrameworkCore;
using web_api_v8.Modules;

namespace web_api_v8.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TouristRoute> touristRoutes { get; set; }

        public DbSet<TouristRoutePicture> touristRoutesPicture { get; set; }
    }
}
