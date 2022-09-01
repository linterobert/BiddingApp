using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyNotificationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CompanyNotificationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyNotification(CreateCompanyNotificationDTO dto)
        {
            var command = _mapper.Map<CreateCompanyNotificationCommand>(dto);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound("Company or product not found!");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyNotificatins()
        {
            var command = new GetCompanyNotificationQuery();
            var result = await _mediator.Send(command);
            var toReturn = _mapper.Map<List<GetCompanyNotificationDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyNotificationByID(int id)
        {
            var query = new GetCompanyNotificationByIDQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Notification not found");
            }
            var toReturn = _mapper.Map<GetCompanyNotificationDTO>(result);
            return Ok(toReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyNotification(int id)
        {
            var command = new DeleteCompanyNotificationCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Notification not found!");
            }

            return NoContent();
        }
    }
}
