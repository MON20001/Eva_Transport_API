using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.FunctionalMapper
{
    public class CreateCompanyDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
    }
}
