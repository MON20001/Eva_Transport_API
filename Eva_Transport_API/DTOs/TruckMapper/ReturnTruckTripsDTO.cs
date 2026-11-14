using Eva_Transport_API.DTOs.BusMapper;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class ReturnTruckTripsDTO
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int TruckId { get; set; }
        public ReturnTruckOfTruckTripDTO? truck { get; set; }
    }
    public class ReturnTruckOfTruckTripDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    
    }
}
