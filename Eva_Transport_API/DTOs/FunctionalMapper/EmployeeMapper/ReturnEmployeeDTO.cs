using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;

namespace Eva_Transport_API.DTOs.FunctionalMapper.EmployeeMapper
{
    public class ReturnEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PickupLocation { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public ReturnCompanyEmployeeDTO? company { get; set; }
        public ICollection<ReturnBusTripEmployeeDTO>? employeeBusTrips { get; set; } = new List<ReturnBusTripEmployeeDTO>();
    }
    public class ReturnCompanyEmployeeDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ReturnBusTripEmployeeDTO
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
    }
}
