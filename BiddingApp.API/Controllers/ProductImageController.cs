using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _repository;

        public ProductImageController(IProductImageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var products = _repository.GetAll();
            var productsToReturn = new List<ProductImageDTO>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductImageDTO(product));
            }
            return Ok(productsToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var product = _repository.GetByIdAsync(id).Result;
            if (product == null)
            {
                return NotFound("Card-ul nu exista!");
            }
            return Ok(new ProductImageDTO(product));
        }
        /*
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
        */
    }
}
