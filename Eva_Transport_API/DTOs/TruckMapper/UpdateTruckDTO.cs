using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class UpdateTruckDTO
    {
        [MaxLength(100, ErrorMessage = "Plate Number cannot exceed 100 characters")]
        public string? PlateNumber { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive number")]
        public int? Capacity { get; set; }
        public bool? Status { get; set; }
        public int? CompanyId { get; set; }
    }
}
