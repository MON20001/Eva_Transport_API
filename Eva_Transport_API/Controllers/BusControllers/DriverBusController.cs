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
    public class DriverBusController : ControllerBase
    {
        protected readonly BusDriverRepo _busDriverRepo;
        protected readonly BusRepo _busRepo;
        protected readonly IMapper _mapper;
        public DriverBusController(BusDriverRepo busDriverRepo, BusRepo busRepo, IMapper mapper)
        {
            _busRepo = busRepo;
            _mapper = mapper;
            _busDriverRepo = busDriverRepo;
        }

        //Add Driver Bus
        [HttpPost]
        public async Task<ActionResult> AddDriverBus(CreateBusDriverDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var driverbusData = _mapper.Map<BusDriver>(dto);

            if(dto.busesId != null)
            {
                foreach (int id in dto.busesId)
                {
                    var buseesData = await _busRepo.GetById(id);
                    if (buseesData == null)
                        return NotFound($"There is no bus with id {id}");
                    driverbusData.buses!.Add(buseesData);
                }
            }
            
            await _busDriverRepo.Add(driverbusData);
            return Ok("Added Successfully");
        }
        //Get All Driver Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnBusDriverDTO?>>> GetAllDriverBus()
        {
            var driversBuses = await _busDriverRepo.GetAll();
            if (driversBuses == null)
                return NotFound("No drivers buses found");
            var driversBusesData = _mapper.Map<IEnumerable<ReturnBusDriverDTO>>(driversBuses);
            return Ok(driversBusesData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBusDriverDTO?>> GetDriverBusById(int id)
        {
            var findDriverBus = await _busDriverRepo.GetById(id);
            if (findDriverBus == null)
                return NotFound($"Bus with ID {id} not found");
            var driverBusData = _mapper.Map<ReturnBusDriverDTO>(findDriverBus);
            return Ok(driverBusData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDriverBus(int id, UpdateBusDriverDTO dto)
        {
            var findDriverBus = await _busDriverRepo.GetById(id);
            if (findDriverBus == null)
                return NotFound($"Bus with ID {id} not found");

            if (!String.IsNullOrWhiteSpace(dto.Name))
                findDriverBus.Name = dto.Name;

            if (!String.IsNullOrWhiteSpace(dto.Type))
                findDriverBus.Type = dto.Type;

            if (!String.IsNullOrWhiteSpace(dto.LicenseNumber))
                findDriverBus.LicenseNumber = dto.LicenseNumber;

            if (!String.IsNullOrWhiteSpace(dto.Phone))
                findDriverBus.Phone = dto.Phone;

            if (dto.Status.HasValue)
                findDriverBus.Status = dto.Status.Value;

            if(dto.busesId != null)
            {
                findDriverBus.buses!.Clear();
                foreach(int getBusesId in dto.busesId)
                {
                    var busData = await _busRepo.GetById(getBusesId);
                    if (busData == null)
                        return NotFound($"Bus with id {getBusesId}");
                    findDriverBus.buses.Add(busData);
                }
            }

            await _busDriverRepo.Update(findDriverBus);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriverBus(int id)
        {
            var driverbusRemove = await _busDriverRepo.Delete(id);
            if (!driverbusRemove)
                return NotFound($"Driver bus with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
