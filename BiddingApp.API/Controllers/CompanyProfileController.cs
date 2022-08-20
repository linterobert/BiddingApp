using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileRepository _repository;
        public CompanyProfileController(ICompanyProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyProfiles()
        {
            var companies = _repository.GetAll();
            var companiesToReturn = new List<CompanyProfileDTO>();

            foreach (var company in companies)
            {
                companiesToReturn.Add(new CompanyProfileDTO(company));
            }
            return Ok(companiesToReturn);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCompany(CreateCompanyProfileDTO dto)
        {
            CompanyProfile company = new CompanyProfile();
            company.CompanyName = dto.CompanyName;
            company.IBAN = dto.IBAN;
            company.ProfilePhotoURL = "default";

            _repository.Create(company);

            await _repository.SaveAsync();
            return Ok(new CompanyProfileDTO(company));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyProfileById(int id)
        {
            var user = _repository.GetCompanyWithProducts(id);
            if (user == null)
            {
                return NotFound("User-ul nu exista!");
            }
            return Ok(new CompanyProfileDTO(user));
        }

        [HttpPut("balance/{id}")]
        public async Task<IActionResult> UpdateCompanyBalance(int id, double sum)
        {
            _repository.UpdateCompanyBalance(id, sum);
            await _repository.SaveAsync();
            return Ok(new CompanyProfileDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpPut("name/{name}")]
        public async Task<IActionResult> UpdateCompanyName(int id, string name)
        {
            if (name != null)
            {
                _repository.UpdateCompanyName(id, name);

            }
            await _repository.SaveAsync();
            return Ok(new CompanyProfileDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyProfile(int id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound("Produsul nu exista!");
            }

            _repository.Delete(client);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
