namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class ReturnTruckReportDTO
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
        public int TruckId { get; set; }
        public ReturnTruckOfTruckReportDTO? truck { get; set; }
    }
    public class ReturnTruckOfTruckReportDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    }
}