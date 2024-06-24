using Microsoft.EntityFrameworkCore;

namespace EFCore_SQLServer
{
    public class MyDbContext:DbContext      
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=c-sharp-learn;Trusted_Connection=True");
        }
    }
}
