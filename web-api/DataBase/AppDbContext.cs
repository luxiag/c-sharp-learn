using Microsoft.EntityFrameworkCore;
using web_api.Modules;

namespace web_api.DataBase
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "Title",
            //    Description = "Description",
            //    OriginalPrice = 0,
            //    CreateTime = DateTime.Now
            //});
              base.OnModelCreating(modelBuilder);

        }
    }
}
