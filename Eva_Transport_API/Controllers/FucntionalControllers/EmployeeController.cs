using AutoMapper;
using Eva_Transport_API.DTOs.FunctionalMapper;
using Eva_Transport_API.DTOs.FunctionalMapper.EmployeeMapper;
using Eva_Transport_API.Models;
using Eva_Transport_API.Repo.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.FucntionalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CompanyRepo _companyRepo;
        private readonly EmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeController(CompanyRepo companyRepo, EmployeeRepo employeeRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        //Get All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnEmployeeDTO?>>> GetAllEmployees()
        {
            var employees = await _employeeRepo.GetAll();
            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found");
            }
            var employeeDTOs = _mapper.Map<IEnumerable<ReturnEmployeeDTO>>(employees);
            return Ok(employeeDTOs);
        }
        //Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepo.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            var employeeDTO = _mapper.Map<ReturnEmployeeDTO>(employee);
            return Ok(employeeDTO);
        }
        //Add
        [HttpPost]
        public async Task<ActionResult> AddEmployee(CreateEmployeeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(dto.CompanyId.ToString() != null)
            {
                var companys = await _companyRepo.GetById(dto.CompanyId);
                if(companys == null)
                {
                    return NotFound("Company not found");
                }
            }
            var employeeData = _mapper.Map<Employee>(dto);

            await _employeeRepo.Add(employeeData);
            return Ok("Employee added successfully");
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeDTO dto)
        {
            var employeeData = await _employeeRepo.GetById(id);
            if(employeeData == null)
            {
                return NotFound("Employee not found");
            }
            if (!string.IsNullOrWhiteSpace(dto.Name))
                employeeData.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.PickupLocation))
                employeeData.PickupLocation = dto.PickupLocation;

            if (!string.IsNullOrWhiteSpace(dto.Phone))
                employeeData.Phone = dto.Phone;

            if (dto.CompanyId.HasValue)
            {
                var companys = await _companyRepo.GetById(dto.CompanyId.Value);
                if (companys == null)
                {
                    return NotFound("Company not found");
                }
                employeeData.CompanyId = dto.CompanyId.Value;
            }

            await _employeeRepo.Update(employeeData);
            return Ok("Employee updated successfully");
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var final = await _employeeRepo.Delete(id);
            if (!final)
            {
                return NotFound("Employee not found");
            }
            return Ok("Employee deleted successfully");
        }
    }
}
