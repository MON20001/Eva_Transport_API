using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class CreateTruckReportDTO
    {
        [MaxLength(200, ErrorMessage = "IssueDescription cannot exceed more than 200 characters")]
        public string? IssueDescription { get; set; }
        [Required(ErrorMessage = "RequestDate is required")]
        public DateTime RequestDate { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "BusId is required")]
        public int TruckId { get; set; }
    }
}
