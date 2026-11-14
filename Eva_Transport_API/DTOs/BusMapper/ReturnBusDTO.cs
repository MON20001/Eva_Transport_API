using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class ReturnBusDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public ReturnCompanyBusDTO? company { get; set; }
        public ICollection<ReturnBusDriverBusDTO>? busDrivers { get; set; } = new List<ReturnBusDriverBusDTO>();
        public ICollection<ReturnReportsBusDTO>? reports { get; set; } = new List<ReturnReportsBusDTO>();
        public ICollection<ReturnBusTripBusDTO>? busTrips { get; set; } = new List<ReturnBusTripBusDTO>();
    }
    public class ReturnCompanyBusDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ReturnBusDriverBusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
    }
    public class ReturnReportsBusDTO
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
    }
    public class ReturnBusTripBusDTO
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
    }
}