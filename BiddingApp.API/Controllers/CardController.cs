using AutoMapper;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
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
        private readonly ILogger _logger;
        public CardController(IMediator mediator, IMapper mapper, ILogger<CardController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardDTO dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create new Card for client with ID {dto.ClientId}");

            var testCard = _mapper.Map<Card>(dto);
            CardValidator validator = new CardValidator();
            ValidationResult valResult = validator.Validate(testCard);

            if (!valResult.IsValid)
            {
                foreach (var error in valResult.Errors)
                {
                    _logger.LogError(error.ToString());
                }
                return BadRequest(valResult.Errors);
            }

            var command = _mapper.Map<CreateCardCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);

            if(result == null)
            {
                _logger.LogError($"Client with id {dto.ClientId} not found!");
                return NotFound("Client not found");
            }
            var toReturn = _mapper.Map<CardDTO>(result);

            _logger.LogInformation($"Card created successfully for client with id {dto.ClientId}");
            return Ok(toReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            _logger.LogInformation($"Get all cards");
            var query = new GetCardsQuery();
            var result = await _mediator.Send(query);


            var toReturn = _mapper.Map<List<CardDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("/cardNumber/{cardNumber}")]
        public async Task<IActionResult> GetCardByCardNumber(string cardNumber)
        {
            _logger.LogInformation($"Get card by card number: {cardNumber}");
            var query = new GetCardByCardNumberQuery
            {
                CardNumber = cardNumber
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Card with card number {cardNumber} not found");
                return NotFound("Card not found!");
            }
            var toReturn = _mapper.Map<CardDTO>(result);
           
            return Ok(toReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            _logger.LogInformation($"Delete card with id {id}");
            var command = new DeleteCardCommand
            {
                CardId = id
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogError($"Card with id {id} not found");
                return NotFound("Cardul nu exista!");
            }

            return NoContent();
        }
    }
}
