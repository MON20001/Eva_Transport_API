using AutoMapper;
using Eva_Transport_API.DTOs.BusMapper;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Repo.AboutBusRepo;
using Eva_Transport_API.Repo.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.BusControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTripController : ControllerBase
    {
        protected readonly BusRepo _busRepo;
        protected readonly EmployeeRepo _employeeRepo;
        protected readonly BusTripRepo _busTripRepo;
        protected readonly IMapper _mapper;
        public BusTripController(BusRepo busRepo,EmployeeRepo employeeRepo,BusTripRepo busTripRepo, IMapper mapper)
        {
            _busRepo = busRepo;
            _employeeRepo = employeeRepo;
            _busTripRepo = busTripRepo;
            _mapper = mapper;
            
        }

        //Add Bus
        [HttpPost]
        public async Task<ActionResult> AddBusTrip(CreateBusTripDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busTripData = _mapper.Map<BusTrip>(dto);

            var buses = await _busRepo.GetById(dto.BusId);
            if (buses == null)
                return NotFound(($"Bus with ID {dto.BusId} not found"));

            if(dto.employeesId != null)
            {
                foreach(int id in dto.employeesId)
                {
                    var employeesData = await _employeeRepo.GetById(id);
                    if (employeesData == null)
                        return NotFound($"Employee with id {id} not found");
                    busTripData.employees!.Add(employeesData);
                }
            }
            await _busTripRepo.Add(busTripData);
            return Ok("Added Successfully");
        }
        //Get All Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnBusTripDTO?>>> GetAllBusesTrip()
        {
            var busesTrip = await _busTripRepo.GetAll();
            if (busesTrip == null)
                return NotFound("No buse trip found");
            var busesTripData = _mapper.Map<IEnumerable<ReturnBusTripDTO>>(busesTrip);
            return Ok(busesTripData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBusTripDTO?>> GetBusTripById(int id)
        {
            var findBusTrip = await _busTripRepo.GetById(id);
            if (findBusTrip == null)
                return NotFound($"Bus trip with ID {id} not found");
            var busTripData = _mapper.Map<ReturnBusTripDTO>(findBusTrip);
            return Ok(busTripData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBus(int id, UpdateBusTripDTO dto)
        {
            var findBusTrip = await _busTripRepo.GetById(id);
            if (findBusTrip == null)
                return NotFound($"Bus trip with ID {id} not found");


            if (dto.TripDate.HasValue)
                findBusTrip.TripDate = dto.TripDate.Value;

            if (dto.StartTime.HasValue)
                findBusTrip.StartTime = dto.StartTime.Value;
            if (dto.EndTime.HasValue)
                findBusTrip.EndTime = dto.EndTime.Value;

            if (dto.Status.HasValue)
                findBusTrip.Status = dto.Status.Value;

            if (dto.BusId.HasValue)
            {
                var companys = await _busRepo.GetById(dto.BusId.Value);
                if (companys == null)
                {
                    return NotFound($"Bus with id {dto.BusId} not found");
                }
                findBusTrip.BusId = dto.BusId.Value;
            }
            if(dto.employeesId != null)
            {
                findBusTrip.employees!.Clear();
                foreach (int Idemployees in dto.employeesId)
                {
                    var employeeData = await _employeeRepo.GetById(Idemployees);
                    if (employeeData == null)
                        return NotFound($"Employee with id {Idemployees} not found");
                    findBusTrip.employees.Add(employeeData);
                }
            }
            await _busTripRepo.Update(findBusTrip);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBus(int id)
        {
            var busTripRemove = await _busTripRepo.Delete(id);
            if (!busTripRemove)
                return NotFound($"Bus trip with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
