using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region Bus
        //Bus
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusDriver> BusDrivers { get; set; }
        public DbSet<BusMaintenanceRequest> BusReports { get; set; }
        #endregion
        #region Truck
        //Truck
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckDriver> TruckDrivers { get; set; }
        public DbSet<TruckMaintenanceRequest> TruckReports { get; set; }
        #endregion
        #region Functional
        //Fuctional
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BusTrip> BusTrips { get; set; }
        public DbSet<TruckTrip> TruckTrips { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
