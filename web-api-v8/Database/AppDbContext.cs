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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "title",
            //    Description = "description",
            //    OriginalPrice = 0,
            //    CreateTime = DateTime.UtcNow,
            //    Features = "Test",
            //    Fees = "Test",
            //    Notes = "Test"
            //});
            //var touristRouteJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutesMockData.json");
            //IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
            //modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);

            base.OnModelCreating(modelBuilder);
        }
    }
}
