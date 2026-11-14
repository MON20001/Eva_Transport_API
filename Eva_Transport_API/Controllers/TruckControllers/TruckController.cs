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
    public class TruckController : ControllerBase
    {
        private readonly TruckRepo _truckRepo;
        private readonly CompanyRepo _companyRepo;
        private readonly IMapper _mapper;
        public TruckController(TruckRepo truckRepo, CompanyRepo companyRepo, IMapper mapper)
        {
            _truckRepo = truckRepo;
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        //Add Truck
        [HttpPost]
        public async Task<ActionResult> AddTruck(CreateTruckDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companys = await _companyRepo.GetById(dto.CompanyId);
            if (companys == null)
                return NotFound(($"Company with ID {dto.CompanyId} not found"));
            
            var truckData = _mapper.Map<Truck>(dto);
            await _truckRepo.Add(truckData);
            return Ok("Added Successfully");
        }
        //Get All Trucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTruckDTO?>>> GetAllTrucks()
        {
            var truckes = await _truckRepo.GetAll();
            if (truckes == null)
                return NotFound("No Truckes found");
            var truckData = _mapper.Map<IEnumerable<ReturnTruckDTO>>(truckes);
            return Ok(truckData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTruckDTO?>> GetTruckById(int id)
        {
            var findTruck = await _truckRepo.GetById(id);
            if (findTruck == null)
                return NotFound($"Truck with ID {id} not found");
            var truckData = _mapper.Map<ReturnTruckDTO>(findTruck);
            return Ok(truckData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTruck(int id, UpdateTruckDTO dto)
        {
            var findTruck = await _truckRepo.GetById(id);
            if (findTruck == null)
                return NotFound($"Bus with ID {id} not found");

            if (!String.IsNullOrWhiteSpace(dto.PlateNumber))
                findTruck.PlateNumber = dto.PlateNumber;

            if (dto.Capacity.HasValue)
                findTruck.Capacity = dto.Capacity.Value;

            if (dto.Status.HasValue)
                findTruck.Status = dto.Status.Value;

            if (dto.CompanyId.HasValue)
            {
                var companys = await _companyRepo.GetById(dto.CompanyId.Value);
                if (companys == null)
                {
                    return NotFound("Company not found");
                }
                findTruck.CompanyId = dto.CompanyId.Value;
            }
            await _truckRepo.Update(findTruck);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTruck(int id)
        {
            var truckRemove = await _truckRepo.Delete(id);
            if (!truckRemove)
                return NotFound($"Truck with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
