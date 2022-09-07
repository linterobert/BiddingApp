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
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CompanyNotificationController(IMediator mediator, IMapper mapper, ILogger<CompanyNotificationController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyNotification(CreateCompanyNotificationDTO dto)
        {
            _logger.LogInformation($"Create notification for company with id {dto.CompanyID}");
            var command = _mapper.Map<CreateCompanyNotificationCommand>(dto);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogInformation($"Company not found");
                return NotFound("Company or product not found!");
            }
            var toReturn = _mapper.Map<GetCompanyNotificationDTO>(result);
            return Ok(toReturn);
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
            _logger.LogInformation($"Delete company notification with id {id}");
            var command = new DeleteCompanyNotificationCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogError("Notification not found");
                return NotFound("Notification not found!");
            }

            return NoContent();
        }
    }
}
