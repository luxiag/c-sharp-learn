
using web_api.Services;
using Microsoft.EntityFrameworkCore;
using web_api.DataBase;
using Microsoft.Extensions.Configuration;

namespace web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            var config = app.Configuration;
            // Add services to the container.

            //builder.Services.AddControllers();

            builder.Services.AddTransient<ITouristRouteRepository, MockTourisRouteRepository>();
            //builder.Services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();



            //builder.Services.AddDbContext<AppDbContext>(option =>
            // {
            //    // SQLService≈‰÷√
            //     //option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FakeXiechengDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //     //option.UseSqlServer("server=localhost; Database=FakeXiechengDb; User Id=sa; Password=PaSSword12!;");
            //     option.UseSqlServer(config["DbContext:ConnectionString"]);
            // });

            // EF Core uses this method at design time to access the DbContext


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }



}
