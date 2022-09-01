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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientNotificationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientNotification(CreateClientNotificationDTO dto)
        {
            var command = _mapper.Map<CreateClientNotificationCommand>(dto);
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Client or product not found!");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientNotificatins()
        {
            var command = new GetClientNotificationsQuery();
            var result = await _mediator.Send(command);
            var toReturn = _mapper.Map<List<GetClientNotificationDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientNotificationByID(int id)
        {
            var query = new GetClientNotificationByIDQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                return NotFound("Notification not found");
            }
            var toReturn = _mapper.Map<GetClientNotificationDTO>(result);
            return Ok(toReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientNotification(int id)
        {
            var command = new DeleteClientNotificationCommand
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
