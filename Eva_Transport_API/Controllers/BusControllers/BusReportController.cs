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
    public class BusReportController : ControllerBase
    {
        protected readonly BusRepo _busRepo;
        protected readonly BusReportRepo _busReportRepo;
        protected readonly IMapper _mapper;
        public BusReportController(BusRepo busRepo, BusReportRepo busReportRepo, IMapper mapper)
        {
            _busRepo = busRepo;
            _busReportRepo = busReportRepo;
            _mapper = mapper;

        }

        //Add Bus
        [HttpPost]
        public async Task<ActionResult> AddBusReport(CreateBusReportDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busReportData = _mapper.Map<BusMaintenanceRequest>(dto);

            var buses = await _busRepo.GetById(dto.BusId);
            if (buses == null)
                return NotFound(($"Bus with ID {dto.BusId} not found"));

            await _busReportRepo.Add(busReportData);
            return Ok("Added Successfully");
        }
        //Get All Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnBusReportDTO?>>> GetAllBusesReport()
        {
            var busesReport = await _busReportRepo.GetAll();
            if (busesReport == null)
                return NotFound("No bus report found");
            var busReportData = _mapper.Map<IEnumerable<ReturnBusReportDTO>>(busesReport);
            return Ok(busReportData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBusReportDTO?>> GetBusReportById(int id)
        {
            var findBusReport = await _busReportRepo.GetById(id);
            if (findBusReport == null)
                return NotFound($"Bus report with ID {id} not found");
            var busReportData = _mapper.Map<ReturnBusReportDTO>(findBusReport);
            return Ok(busReportData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBusReport(int id, UpdateBusReportDTO dto)
        {
            var findBusReport = await _busReportRepo.GetById(id);
            if (findBusReport == null)
                return NotFound($"Bus report with ID {id} not found");


            if (!string.IsNullOrWhiteSpace(dto.IssueDescription))
                findBusReport.IssueDescription = dto.IssueDescription;

            if (dto.RequestDate.HasValue)
                findBusReport.RequestDate = dto.RequestDate.Value;

            if (dto.Status.HasValue)
                findBusReport.Status = dto.Status.Value;

            await _busReportRepo.Update(findBusReport);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusReport(int id)
        {
            var busReportRemove = await _busReportRepo.Delete(id);
            if (!busReportRemove)
                return NotFound($"Bus report with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
