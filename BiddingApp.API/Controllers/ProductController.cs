using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IClientProfileRepository _profileRepository;
        private readonly IClientNotificationRepository _clientNotificationRepository;

        public ProductController(IProductRepository repository, IClientProfileRepository profileRepository, IClientNotificationRepository clientNotificationRepository)
        {
            _repository = repository;
            _profileRepository = profileRepository;
            _clientNotificationRepository = clientNotificationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = _repository.GetAll();
            var productsToReturn = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductDTO(product));
            }
            return Ok(productsToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = _repository.GetByIdAsync(id).Result;
            if (product == null)
            {
                return NotFound("Card-ul nu exista!");
            }
            return Ok(new ProductDTO(product));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            Product product = new Product();
            product.ProductName = dto.ProductName;
            product.CompanyProfileId = dto.CompanyId;
            product.ActualPrice = dto.StartPrice;
            product.CashOut = false;
            product.FinalTime = dto.FinalTime;
            product.StartPrice = dto.StartPrice;

            _repository.Create(product);

            await _repository.SaveAsync();
            return Ok(new ProductDTO(product));
        }

        [HttpPut("{id}/offer/{clientId}")]
        public async Task<IActionResult> MakeOffer(int id, int clientId, double sum)
        {
            var product = _repository.GetByIdAsync(id).Result;
            var client = _profileRepository.GetByIdAsync(clientId).Result;
            if (product.ActualPrice <= sum 
                && product.FinalTime.CompareTo(DateTime.Now) >= 0 
                && client.Balance >= sum)
            {
                product.ActualPrice = Math.Round(sum * (1 + Product.BitConstant),2);
                product.ClientProfileId = clientId;
                _repository.Update(product);
                client.Balance = Math.Round(client.Balance - sum, 2);
                _profileRepository.Update(client);
                double x = product.FinalTime.Subtract(DateTime.Now).TotalSeconds;
                if (x <= 30)
                {
                    product.FinalTime = product.FinalTime.AddMinutes(1);
                }
                await _profileRepository.SaveAsync();
                await _repository.SaveAsync();
            }
            return Ok(new ProductDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpPut("price/{id}")]
        public async Task<IActionResult> UpdateCompanyBalance(int id, double sum)
        {
            _repository.UpdatePrice(id, sum);
            await _repository.SaveAsync();
            return Ok(new ProductDTO(_repository.GetByIdAsync(id).Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
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
