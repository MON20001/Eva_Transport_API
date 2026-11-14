using AutoMapper;
using Eva_Transport_API.DTOs.BusMapper;
using Eva_Transport_API.DTOs.TruckMapper;
using Eva_Transport_API.Models.AboutTruck;
using Eva_Transport_API.Repo.AboutTruckRepo;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.TruckControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckReportController : ControllerBase
    {
        protected readonly TruckRepo _truckRepo;
        protected readonly TruckReportRepo _truckReportRepo;
        protected readonly IMapper _mapper;
        public TruckReportController(TruckRepo truckRepo, TruckReportRepo trucReportRepo, IMapper mapper)
        {
            _truckRepo = truckRepo;
            _truckReportRepo = trucReportRepo;
            _mapper = mapper;

        }

        //Add Bus
        [HttpPost]
        public async Task<ActionResult> AddTruckReport(CreateTruckReportDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var truckReportData = _mapper.Map<TruckMaintenanceRequest>(dto);

            var truckes = await _truckRepo.GetById(dto.TruckId);
            if (truckes == null)
                return NotFound(($"Trucke with ID {dto.TruckId} not found"));

            await _truckReportRepo.Add(truckReportData);
            return Ok("Added Successfully");
        }
        //Get All Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTruckReportDTO?>>> GetAllTruckesReport()
        {
            var truckesReport = await _truckReportRepo.GetAll();
            if (truckesReport == null)
                return NotFound("No truck report found");
            var truckReportData = _mapper.Map<IEnumerable<ReturnTruckReportDTO>>(truckesReport);
            return Ok(truckReportData);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTruckReportDTO?>> GetTruckReportById(int id)
        {
            var findTruckReport = await _truckReportRepo.GetById(id);
            if (findTruckReport == null)
                return NotFound($"Truck report with ID {id} not found");
            var truckReportData = _mapper.Map<ReturnTruckReportDTO>(findTruckReport);
            return Ok(truckReportData);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBusReport(int id, UpdateTruckReportDTO dto)
        {
            var findTruckReport = await _truckReportRepo.GetById(id);
            if (findTruckReport == null)
                return NotFound($"Truck report with ID {id} not found");


            if (!string.IsNullOrWhiteSpace(dto.IssueDescription))
                findTruckReport.IssueDescription = dto.IssueDescription;

            if (dto.RequestDate.HasValue)
                findTruckReport.RequestDate = dto.RequestDate.Value;

            if (dto.Status.HasValue)
                findTruckReport.Status = dto.Status.Value;

            await _truckReportRepo.Update(findTruckReport);
            return Ok("Update Success");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTruckReport(int id)
        {
            var truckReportRemove = await _truckReportRepo.Delete(id);
            if (!truckReportRemove)
                return NotFound($"Truck report with id {id} not found");

            return Ok("Remove Success");
        }
    }
}
