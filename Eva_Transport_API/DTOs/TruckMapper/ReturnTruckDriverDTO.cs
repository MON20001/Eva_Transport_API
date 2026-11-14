namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class ReturnTruckDriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<ReturnTruckOfTruckDriverDTO>? trucks { get; set; } = new List<ReturnTruckOfTruckDriverDTO>();
    }
    public class ReturnTruckOfTruckDriverDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
