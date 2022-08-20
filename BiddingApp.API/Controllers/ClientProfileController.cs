using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfileController : ControllerBase
    {

        private readonly IClientProfileRepository _repository;
        private readonly ICardRepository _cardRepository;
        public ClientProfileController(IClientProfileRepository repository, ICardRepository cardRepository)
        {
            _repository = repository;
            _cardRepository = cardRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetClientProfiles()
        {
            var clients = _repository.GetAll();
            var clientsToReturn = new List<ClientProfileDTO>();

            foreach (var client in clients)
            {
                clientsToReturn.Add(new ClientProfileDTO(client));
            }
            return Ok(clientsToReturn);
        }

        [HttpPost]

        public async Task<IActionResult> CreateClient(CreateClientProfileDTO dto)
        {
            ClientProfile client = new ClientProfile();
            client.ClientName = dto.ClientName;
            client.Balance = 0.00;
            client.Cards = new List<Card>();
            client.ProductsOwn = new List<Product>();
            client.Reviews = new List<Review>();
            client.ProfilePhotoURL = "default";

            _repository.Create(client);

            await _repository.SaveAsync();
            return Ok(new ClientProfileDTO(client));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetClientProfileById(int id)
        {
            var user = _repository.GetClientProfileById(id);
            if (user == null)
            {
                return NotFound("User-ul nu exista!");
            }
            return Ok(new ClientProfileDTO(user));
        }

        [HttpPut("balance/{id}")]
        public async Task<IActionResult> UpdateClientBalance(int id, double sum)
        {
            _repository.UpdateBalance(id, sum);
            await _repository.SaveAsync();
            return Ok(new ClientProfileDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpPut("name/{name}")]
        public async Task<IActionResult> UpdateClientName(int id, string name)
        {
            if (name != null)
            {
                _repository.UpdateClientName(id, name);

            }
            await _repository.SaveAsync();
            return Ok(new ClientProfileDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpPut("{id}/funds/{cardNumber}")]
        public async Task<IActionResult> UpdateClientName(int id, double sum, string cardNumber, string CVC, string Pin)
        {
            var card = _cardRepository.GetCardByCardNumber(cardNumber);
            if (card != null)
            {
                if (card.ExpireDate.CompareTo(DateTime.Now) >= 0 && card.Pin == Pin && card.CVC == CVC)
                {
                    _repository.UpdateBalance(id, sum);
                }

            }
            await _repository.SaveAsync();
            return Ok(new ClientProfileDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile(int id)
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
