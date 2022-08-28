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
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CardController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardDTO dto)
        {
            var command = _mapper.Map<CreateCardCommand>(dto);
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Client not found");
            }
            var toReturn = _mapper.Map<CardDTO>(result);

            return Ok(toReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var query = new GetCardsQuery();
            var result = await _mediator.Send(query);

            var toReturn = _mapper.Map<List<CardDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/CardNumber/{cardNumber}")]
        public async Task<IActionResult> GetCardByCardNumber(string cardNumber)
        {
            var query = new GetCardByCardNumberQuery
            {
                CardNumber = cardNumber
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Card not found!");
            }
            var toReturn = _mapper.Map<CardDTO>(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var command = new DeleteCardCommand
            {
                CardId = id
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Cardul nu exista!");
            }

            return NoContent();
        }
    }
}
