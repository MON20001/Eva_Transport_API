using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PickupLocation { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public Company? company { get; set; }
        public ICollection<BusTrip>? employeeBusTrips { get; set; } = new List<BusTrip>();
    }
}
