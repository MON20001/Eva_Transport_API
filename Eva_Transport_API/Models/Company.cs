using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;

namespace Eva_Transport_API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Bus>? buses { get; set; } = new List<Bus>();
        public ICollection<Truck>? trucks { get; set; } = new List<Truck>();
        public ICollection<Employee>? employees { get; set; } = new List<Employee>();

    }
}
