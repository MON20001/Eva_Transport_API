using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.FunctionalMapper.EmployeeMapper
{
    public class UpdateEmployeeDTO
    {
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
        [MaxLength(100, ErrorMessage = "Pickup location cannot exceed 100 characters")]
        public string? PickupLocation { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        [MaxLength(11,ErrorMessage ="Phone must be = 11 numbers")]
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
    }
}
