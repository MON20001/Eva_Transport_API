using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.BusMapper
{
    public class UpdateBusDriverDTO
    {
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string? Name { get; set; }
        [MaxLength(50, ErrorMessage = "Type cannot exceed 100 characters")]
        public string? Type { get; set; }
        [MaxLength(100, ErrorMessage = "License Number cannot exceed 100 characters")]
        public string? LicenseNumber { get; set; }
        [Phone(ErrorMessage = "Enter a valid Phone Number")]
        [MaxLength(11, ErrorMessage = "Phone Number cannot more than 11 characters")]
        public string? Phone { get; set; }
        public bool? Status { get; set; }
        public List<int>? busesId { get; set; } = new List<int>();
    }
}
