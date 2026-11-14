namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class ReturnTruckDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public ReturnCompanyTruckDTO? company { get; set; }
        public ICollection<ReturnTruckDriverOfTruckDTO>? truckDrivers { get; set; } = new List<ReturnTruckDriverOfTruckDTO>();
        public ICollection<ReturnReportsTruckDTO>? reports { get; set; } = new List<ReturnReportsTruckDTO>();
        public ICollection<ReturnTruckTripDTO>? truckTrips { get; set; } = new List<ReturnTruckTripDTO>();
    }
    public class ReturnCompanyTruckDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ReturnTruckDriverOfTruckDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
    }
    public class ReturnReportsTruckDTO
    {
        public int Id { get; set; }
        public string? IssueDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }
    }
    public class ReturnTruckTripDTO
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
    }

}
