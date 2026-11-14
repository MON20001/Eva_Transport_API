using System.ComponentModel.DataAnnotations;

namespace Eva_Transport_API.DTOs.TruckMapper
{
    public class UpdateTruckReportDTO
    {
        [MaxLength(200, ErrorMessage = "IssueDescription cannot exceed more than 200 characters")]
        public string? IssueDescription { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? Status { get; set; }
    }
}
