using Eva_Transport_API.Models.AboutTruck;
using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class CreateTruckTripDTO
    {
        [Required(ErrorMessage = "Trip Date is required")]
        public DateTime TripDate { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Truck Id is required")]
        public int TruckId { get; set; }

    }
}
