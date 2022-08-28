using AutoMapper;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CompanyProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyProfileDTO dto)
        {
            var command = _mapper.Map<CreateCompanyProfileCommand>(dto);
            var created = await _mediator.Send(command);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyProfiles()
        {
            var query = new GetCompanyProfilesQuery();
            var result = await _mediator.Send(query);
            var toReturn = _mapper.Map<List<GetCompanyProfileDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyProfileById(int id)
        {
            var query = new GetCompanyProfileByIDQuery
            {
                CompanyProfileId = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<GetCompanyProfileDTO>(result);
            return Ok(toReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyBalance(int id, [FromBody] UpdateCompanyDTO dto)
        {
            var command = new UpdateCompanyProfileCommand
            {
                CompanyProfileId = id,
                IBAN = dto.IBAN,
                ProfilePhotoURL = dto.ProfilePhotoURL,
                CompanyBalance = dto.CompanyBalance,
                CompanyName = dto.CompanyName
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Company not found!");
            }
            var toReturn = _mapper.Map<GetCompanyProfileDTO>(result);
            return Ok(toReturn);
        }

        [HttpPut("{id}/CashOutProduct/{productId}")]
        public async Task<IActionResult> CashOutObject(int id, int productId)
        {
            var command = new CashOutProductCommand
            {
                ProductId = productId,
                CompanyId = id
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound();
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyProfile(int id)
        {
            var command = new DeleteCompanyProfileCommand
            {
                CompanyId = id
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Company not found!");
            }
            return NoContent();
        }
    }
}
