using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class UpdateBusTripDTO
    {
        public DateTime? TripDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Status { get; set; }
        public int? BusId { get; set; }
        public List<int>? employeesId { get; set; } = new List<int>();
    }
}
