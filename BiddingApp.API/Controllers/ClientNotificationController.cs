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
    public class ClientNotificationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientNotificationController(IMediator mediator, IMapper mapper, ILogger<ClientNotificationController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientNotification(CreateClientNotificationDTO dto)
        {
            _logger.LogInformation($"Create client notification for client with id {dto.ClientID}");
            var command = _mapper.Map<CreateClientNotificationCommand>(dto);
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError($"Client with id {dto.ClientID} or product with id {dto.ProductID} not found");
                return NotFound("Client or product not found!");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientNotificatins()
        {
            _logger.LogInformation("Get all clients notifications");
            var command = new GetClientNotificationsQuery();
            var result = await _mediator.Send(command);
            var toReturn = _mapper.Map<List<GetClientNotificationDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientNotificationByID(int id)
        {
            _logger.LogInformation($"Get client notification with id {id}");
            var query = new GetClientNotificationByIDQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                _logger.LogError("Notification not found!");
                return NotFound("Notification not found");
            }

            var toReturn = _mapper.Map<GetClientNotificationDTO>(result);

            return Ok(toReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientNotification(int id)
        {
            _logger.LogInformation($"Delete notification with id {id}");
            var command = new DeleteClientNotificationCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogError($"Notification with id {id} not found");
                return NotFound("Notification not found!");
            }

            return NoContent();
        }
    }
}
