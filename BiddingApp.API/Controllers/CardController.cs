using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _repository;
        public CardController(ICardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var cards = _repository.GetAll();
            var cardsToReturn = new List<CardDTO>();

            foreach (var card in cards)
            {
                cardsToReturn.Add(new CardDTO(card));
            }
            return Ok(cardsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardByCardNumber(string CardNumber)
        {
            var card = _repository.GetCardByCardNumber(CardNumber);
            if (card == null)
            {
                return NotFound("Card-ul nu exista!");
            }
            return Ok(new CardDTO(card));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateCardDTO dto)
        {
            Card card = new Card();
            card.CardNumber = dto.CardNumber;
            card.ClientProfileId = dto.ClientId;
            card.Pin = dto.PIN;
            card.CVC = dto.CVC;
            card.ExpireDate = dto.ExpireDate;
            
            _repository.Create(card);
            await _repository.SaveAsync();
            return Ok(new CardDTO(card));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
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
