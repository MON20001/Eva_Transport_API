namespace Eva_Transport_API.Models.AboutBus
{
    public class BusDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<Bus>? buses { get; set; } = new List<Bus>();
    }
}
