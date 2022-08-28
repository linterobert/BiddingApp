using AutoMapper;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientProfileDTO dto)
        {
            var command = _mapper.Map<CreateClientProfileCommand>(dto);
            var created = await _mediator.Send(command);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientProfiles()
        {
            var query = new GetClientsQuery();
            var result = await _mediator.Send(query);
            var clients = _mapper.Map<List<ClientProfileGetDTO>>(result);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProfileById(int id)
        {
            var query = new GetClientProfileByIDQuery { ClientProfileId = id };
            var result = await _mediator.Send(query);

            var client = _mapper.Map<ClientProfileDTO>(result);

            if(client == null)
            {
                return NotFound("Client not found!");
            }
            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientProfilePutDTO dto)
        {

            var command = new UpdateClientCommand
            {
                ClientName = dto.ClientName,
                ClientProfileId = id,
                Balance = dto.Balance,
                ProfilePhotoURL = dto.ProfilePhotoURL
            };

            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client not found!");
            }

            return Ok(command);
        }

        [HttpPut("{id}/product/{productId}/offer/{sum}")]
        public async Task<IActionResult> MakeOffer(int id, int productId, double sum)
        {
            var command = new MakeOfferCommand
            {
                ClientId = id,
                ProductId = productId,
                sum = sum
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound();
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }

        [HttpPut("{id}/funds/{cardNumber}")]
        public async Task<IActionResult> AddFunds(int id, string cardNumber, [FromBody] AddFundsDTO dto)
        {
            var command = new AddFundsCommand
            {
                ClientProfileId = id,
                Sum = dto.Sum,
                CardNumber = cardNumber,
                CVC = dto.CVC,
                PIN = dto.Pin
            };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client or card not found!");
            }
            var toReturn = _mapper.Map<ClientProfileGetDTO>(result);
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile(int id)
        {
            var command = new DeleteClientProfileCommand
            {
                ClientProfileId = id
            };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound("Client not found!");
            }

            return NoContent();
        }
    }

}
