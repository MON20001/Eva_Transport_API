using Eva_Transport_API.Data;
using Eva_Transport_API.Help;
using Eva_Transport_API.Repo;
using Eva_Transport_API.Repo.AboutBusRepo;
using Eva_Transport_API.Repo.AboutTruckRepo;
using Eva_Transport_API.Repo.Functional;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Database
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repository
            builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
            builder.Services.AddScoped(typeof(CompanyRepo));
            builder.Services.AddScoped(typeof(EmployeeRepo));
            builder.Services.AddScoped(typeof(BusRepo));
            builder.Services.AddScoped(typeof(BusDriverRepo));
            builder.Services.AddScoped(typeof(BusTripRepo));
            builder.Services.AddScoped(typeof(BusReportRepo));
            builder.Services.AddScoped(typeof(TruckRepo));
            builder.Services.AddScoped(typeof(TruckDriverRepo));
            builder.Services.AddScoped(typeof(TruckTripRepo));
            builder.Services.AddScoped(typeof(TruckReportRepo));

            //Add Mapper
            builder.Services.AddAutoMapper(typeof(ProfileMapping));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
