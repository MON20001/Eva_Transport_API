using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class CreateBusTripDTO
    {
        [Required(ErrorMessage = "Trip Date is required")]
        public DateTime TripDate { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Bus Id is required")]
        public int BusId { get; set; }
        public List<int>? employeesId { get; set; } = new List<int>();
    }
}
