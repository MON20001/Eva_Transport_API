using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class CreateTruckDriverDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [MaxLength(50, ErrorMessage = "Type cannot exceed 100 characters")]
        public string Type { get; set; }
        [Required(ErrorMessage = "License Number is required")]
        [MaxLength(100, ErrorMessage = "License Number cannot exceed 100 characters")]
        public string LicenseNumber { get; set; }
        [Phone(ErrorMessage = "Enter a valid Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [MaxLength(11, ErrorMessage = "Phone Number cannot more than 11 characters")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Bus Id is required")]
        public List<int>? trucksId { get; set; } = new List<int>();
    }
}
