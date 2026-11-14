using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.Models.AboutTruck
{
    public class TruckMaintenanceRequest
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
        public int TruckId { get; set; }
        public Truck? truck { get; set; }
    }
}
