using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class ReturnBusReportDTO
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
        public int BusId { get; set; }
        public ReturnBusOfBusReportDTO? bus { get; set; }
    }
    public class ReturnBusOfBusReportDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    }
}
