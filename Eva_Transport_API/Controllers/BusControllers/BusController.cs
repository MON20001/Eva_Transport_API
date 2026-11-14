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
    public class BusController : ControllerBase
    {
        protected readonly BusRepo _busRepo;
        protected readonly CompanyRepo _companyRepo;
        protected readonly IMapper _mapper;
        public BusController(BusRepo busRepo, IMapper mapper, CompanyRepo companyRepo)
        {
            _busRepo = busRepo;
            _mapper = mapper;
            _companyRepo = companyRepo;
        } 

        //Add Bus
        [HttpPost]
        public async Task<ActionResult> AddBus(CreateBusDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companys = await _companyRepo.GetById(dto.CompanyId);
            if (companys == null)
                return NotFound(($"Company with ID {dto.CompanyId} not found"));

            var busData = _mapper.Map<Bus>(dto);
            await _busRepo.Add(busData);
            return Ok("Added Successfully");
        }
        //Get All Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnBusDTO?>>> GetAllBus()
        {
            var buses = await _busRepo.GetAll();
            if (buses == null)
                return NotFound("No buses found");
            var busesData = _mapper.Map<IEnumerable<ReturnBusDTO>>(buses);
            return Ok(busesData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBusDTO?>> GetBusById(int id)
        {
            var findBus = await _busRepo.GetById(id);
            if(findBus == null)
                return NotFound($"Bus with ID {id} not found");
            var busData = _mapper.Map<ReturnBusDTO>(findBus);
            return Ok(busData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBus(int id , UpdateBusDTO dto)
        {
            var findBus = await _busRepo.GetById(id);
            if(findBus == null)
                return NotFound($"Bus with ID {id} not found");

            if(!String.IsNullOrWhiteSpace(dto.PlateNumber))
                findBus.PlateNumber = dto.PlateNumber;

            if (dto.Capacity.HasValue)
               findBus.Capacity = dto.Capacity.Value;

            if (dto.Status.HasValue)
                findBus.Status = dto.Status.Value;

            if (dto.CompanyId.HasValue)
            {
                var companys = await _companyRepo.GetById(dto.CompanyId.Value);
                if (companys == null)
                {
                    return NotFound("Company not found");
                }
                findBus.CompanyId = dto.CompanyId.Value;
            }
            await _busRepo.Update(findBus);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBus(int id)
        {
            var busRemove = await _busRepo.Delete(id);
            if (!busRemove)
                return NotFound($"Bus with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
