using Eva_Transport_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.FunctionalMapper.EmployeeMapper
{
    public class CreateEmployeeDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pickup location is required")]
        [MaxLength(100, ErrorMessage = "Pickup location cannot exceed 100 characters")]
        public string PickupLocation { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(11, ErrorMessage = "Phone must be = 11 numbers")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }
    }
}
