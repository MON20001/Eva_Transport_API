using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class ReturnBusTripDTO
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int BusId { get; set; }
        public ReturnBusOfBusTripDTO? bus { get; set; }
        public ICollection<ReturnEmployeeBusTripDTO>? employees { get; set; } = new List<ReturnEmployeeBusTripDTO>();
    }
    public class ReturnBusOfBusTripDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    }
    public class ReturnEmployeeBusTripDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PickupLocation { get; set; }
    }
}