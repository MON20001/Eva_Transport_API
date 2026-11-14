using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.Models.AboutTruck
{
    public class Truck
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public Company? company { get; set; }
        public ICollection<TruckDriver>? truckDrivers { get; set; } = new List<TruckDriver>();
        public ICollection<TruckMaintenanceRequest>? reports { get; set; } = new List<TruckMaintenanceRequest>();
        public ICollection<TruckTrip>? trucktrips { get; set; } = new List<TruckTrip>();


    }
}
