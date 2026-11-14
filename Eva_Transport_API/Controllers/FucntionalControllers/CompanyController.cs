using AutoMapper;
using Eva_Transport_API.DTOs.FunctionalMapper;
using Eva_Transport_API.Models;
using Eva_Transport_API.Repo.Functional;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_Transport_API.Controllers.FucntionalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyRepo _companyRepo;
        private readonly IMapper _mapper;
        public CompanyController(CompanyRepo companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> AddCompany(CreateCompanyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyData = _mapper.Map<Company>(dto);

            await _companyRepo.Add(companyData);
            return Ok("Company added successfully");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var final = await _companyRepo.Delete(id);
            if(!final)
            {
                return NotFound("Company not found");
            }
            return Ok("Company deleted successfully");
        }
    }
}
