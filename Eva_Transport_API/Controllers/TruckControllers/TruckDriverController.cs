using AutoMapper;
using Eva_Transport_API.DTOs.BusMapper;
using Eva_Transport_API.DTOs.TruckMapper;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Eva_Transport_API.Repo.AboutBusRepo;
using Eva_Transport_API.Repo.AboutTruckRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.TruckControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckDriverController : ControllerBase
    {
        protected readonly TruckDriverRepo _truckDriverRepo;
        protected readonly TruckRepo _truckRepo;
        protected readonly IMapper _mapper;
        public TruckDriverController(TruckDriverRepo truckDriverRepo, TruckRepo truckRepo, IMapper mapper)
        {
            _truckDriverRepo = truckDriverRepo;
            _mapper = mapper;
            _truckRepo = truckRepo;
        }

        //Add Driver Truck
        [HttpPost]
        public async Task<ActionResult> AddDriverBus(CreateTruckDriverDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var driverTruckData = _mapper.Map<TruckDriver>(dto);

            if (dto.trucksId != null)
            {
                foreach (int id in dto.trucksId)
                {
                    var truckesData = await _truckRepo.GetById(id);
                    if (truckesData == null)
                        return NotFound($"There is no truck with id {id}");
                    driverTruckData.trucks!.Add(truckesData);
                }
            }

            await _truckDriverRepo.Add(driverTruckData);
            return Ok("Added Successfully");
        }
        //Get All Driver Truck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTruckDriverDTO?>>> GetAllDriverBus()
        {
            var driversTrucks = await _truckDriverRepo.GetAll();
            if (driversTrucks == null)
                return NotFound("No drivers trucks found");
            var driversTruckesData = _mapper.Map<IEnumerable<ReturnTruckDriverDTO>>(driversTrucks);
            return Ok(driversTruckesData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTruckDriverDTO?>> GetDriverBusById(int id)
        {
            var findDriverTruck = await _truckDriverRepo.GetById(id);
            if (findDriverTruck == null)
                return NotFound($"Truck with ID {id} not found");
            var driverTruckData = _mapper.Map<ReturnTruckDriverDTO>(findDriverTruck);
            return Ok(driverTruckData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDriverBus(int id, UpdateTruckDriverDTO dto)
        {
            var findDriverTruck = await _truckDriverRepo.GetById(id);
            if (findDriverTruck == null)
                return NotFound($"Truck with ID {id} not found");

            if (!String.IsNullOrWhiteSpace(dto.Name))
                findDriverTruck.Name = dto.Name;

            if (!String.IsNullOrWhiteSpace(dto.Type))
                findDriverTruck.Type = dto.Type;

            if (!String.IsNullOrWhiteSpace(dto.LicenseNumber))
                findDriverTruck.LicenseNumber = dto.LicenseNumber;

            if (!String.IsNullOrWhiteSpace(dto.Phone))
                findDriverTruck.Phone = dto.Phone;

            if (dto.Status.HasValue)
                findDriverTruck.Status = dto.Status.Value;

            if (dto.trucksId != null)
            {
                findDriverTruck.trucks!.Clear();
                foreach (int getBusesId in dto.trucksId)
                {
                    var busData = await _truckRepo.GetById(getBusesId);
                    if (busData == null)
                        return NotFound($"Truck with id {getBusesId}");
                    findDriverTruck.trucks.Add(busData);
                }
            }

            await _truckDriverRepo.Update(findDriverTruck);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriverBus(int id)
        {
            var driverTruckRemove = await _truckDriverRepo.Delete(id);
            if (!driverTruckRemove)
                return NotFound($"Driver Truck with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
