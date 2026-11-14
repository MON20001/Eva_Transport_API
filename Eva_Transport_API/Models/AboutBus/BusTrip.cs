using Eva_Transport_API.Models.AboutTruck;

namespace Eva_Transport_API.Models.AboutBus
{
    public class BusTrip
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int BusId { get; set; }
        public Bus? bus { get; set; }
        public ICollection<Employee>? employees { get; set; } = new List<Employee>();
    }
}
