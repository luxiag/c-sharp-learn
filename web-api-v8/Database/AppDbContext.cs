using Microsoft.EntityFrameworkCore;
using web_api_v8.Modules;

namespace web_api_v8.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }

        public DbSet<TouristRoutePicture> TouristRoutesPicture { get; set; }
    }
}
