using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.Models.AboutTruck
{
    public class TruckTrip
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int TruckId { get; set; }
        public Truck? truck { get; set; }
    }
}
