using Microsoft.EntityFrameworkCore;
using web_api.Modules;

namespace web_api.DataBase
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> touristRoutePictures { get; set; }
    }
}
