namespace Eva_Transport_API.Models.AboutBus
{
    public class Bus
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public Company? company { get; set; }
        public ICollection<BusDriver>? busDrivers { get; set; } = new List<BusDriver>();
        public ICollection<BusMaintenanceRequest>? reports { get; set; } = new List<BusMaintenanceRequest>();
        public ICollection<BusTrip>? busTrips { get; set; } = new List<BusTrip>();
    }
}
