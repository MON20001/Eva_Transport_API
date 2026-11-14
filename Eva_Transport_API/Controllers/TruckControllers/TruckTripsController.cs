using AutoMapper;
using Eva_Transport_API.DTOs.BusMapper;
using Eva_Transport_API.DTOs.TruckMapper;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Eva_Transport_API.Repo.AboutBusRepo;
using Eva_Transport_API.Repo.AboutTruckRepo;
using Eva_Transport_API.Repo.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.TruckControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckTripsController : ControllerBase
    {
        protected readonly TruckRepo _truckRepo;
        protected readonly TruckTripRepo _truckTripRepo;
        protected readonly IMapper _mapper;
        public TruckTripsController(TruckRepo truckRepo, TruckTripRepo truckTripRepo, IMapper mapper)
        {
            _truckRepo = truckRepo;
            _truckTripRepo = truckTripRepo;
            _mapper = mapper;

        }

        //Add Bus
        [HttpPost]
        public async Task<ActionResult> AddBusTrip(CreateTruckTripDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var truckTripData = _mapper.Map<TruckTrip>(dto);

            var trucks = await _truckRepo.GetById(dto.TruckId);
            if (trucks == null)
                return NotFound(($"Truck with ID {dto.TruckId} not found"));

            
            await _truckTripRepo.Add(truckTripData);
            return Ok("Added Successfully");
        }
        //Get All Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTruckTripDTO?>>> GetAllBusesTrip()
        {
            var truckesTrip = await _truckTripRepo.GetAll();
            if (truckesTrip == null)
                return NotFound("No truckes trip found");
            var TruckTripData = _mapper.Map<IEnumerable<ReturnTruckTripDTO>>(truckesTrip);
            return Ok(TruckTripData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTruckTripDTO?>> GetBusTripById(int id)
        {
            var findTruckTrip = await _truckTripRepo.GetById(id);
            if (findTruckTrip == null)
                return NotFound($"Truck trip with ID {id} not found");
            var truckTripData = _mapper.Map<ReturnTruckTripDTO>(findTruckTrip);
            return Ok(truckTripData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBus(int id, UpdateTruckTripDTO dto)
        {
            var findTruckTrip = await _truckTripRepo.GetById(id);
            if (findTruckTrip == null)
                return NotFound($"Truck trip with ID {id} not found");


            if (dto.TripDate.HasValue)
                findTruckTrip.TripDate = dto.TripDate.Value;

            if (dto.StartTime.HasValue)
                findTruckTrip.StartTime = dto.StartTime.Value;
            if (dto.EndTime.HasValue)
                findTruckTrip.EndTime = dto.EndTime.Value;

            if (dto.Status.HasValue)
                findTruckTrip.Status = dto.Status.Value;

            if (dto.TruckId.HasValue)
            {
                var companys = await _truckRepo.GetById(dto.TruckId.Value);
                if (companys == null)
                {
                    return NotFound($"Truck with id {dto.TruckId} not found");
                }
                findTruckTrip.TruckId = dto.TruckId.Value;
            }
            await _truckTripRepo.Update(findTruckTrip);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBus(int id)
        {
            var truckTripRemove = await _truckTripRepo.Delete(id);
            if (!truckTripRemove)
                return NotFound($"Truck trip with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
