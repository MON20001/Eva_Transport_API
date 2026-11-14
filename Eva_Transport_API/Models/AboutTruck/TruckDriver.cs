namespace Eva_Transport_API.Models.AboutTruck
{
    public class TruckDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<Truck>? trucks { get; set; } = new List<Truck>();

    }
}
