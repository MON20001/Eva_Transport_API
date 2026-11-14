namespace Eva_Transport_API.Models.AboutBus
{
    public class BusMaintenanceRequest
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
        public int BusId { get; set; }
        public Bus? bus { get; set; }
    }
}
