using AutoMapper;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductImageController(IMediator mediator, IMapper mapper, ILogger<ProductImageController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> PostProductImage(CreateProductImageDTO dto)
        {
            _logger.LogInformation("Create product image");
            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ToString());
                return BadRequest(ModelState);
            }
            var command = new CreateProductImageCommand
            {
                Title = dto.Title,
                Description = dto.Description,
                URL = dto.URL,
                ProductId = dto.ProductId
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError($"Product with id {dto.ProductId} not found");
                return NotFound("Product not found!");
            }
            var toReturn = _mapper.Map<ProductImageDTO>(result);
            return Ok(toReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            _logger.LogInformation($"Get image with id {id}");
            var query = new GetImageByIDQuery
            {
                ImageID = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogInformation($"Image with id {id} not found");
                return NotFound("Image not found!");
            }
            var toReturn = _mapper.Map<ProductImageDTO>(result);
            return Ok(toReturn);
        }
    }
}
