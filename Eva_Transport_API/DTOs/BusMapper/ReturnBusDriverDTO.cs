using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class ReturnBusDriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<ReturnBusOfBusDriverDTO>? buses { get; set; } = new List<ReturnBusOfBusDriverDTO>();
    }
    public class ReturnBusOfBusDriverDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
