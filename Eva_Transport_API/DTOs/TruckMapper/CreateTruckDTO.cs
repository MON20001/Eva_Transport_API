using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class CreateTruckDTO
    {
        [Required(ErrorMessage = "Plate Number is required")]
        [MaxLength(100, ErrorMessage = "Plate Number cannot exceed 100 characters")]
        public string PlateNumber { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive number")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Company ID is required")]
        public int CompanyId { get; set; }
    }
}
