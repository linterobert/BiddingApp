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
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            _logger.LogInformation($"Create new Product");

            var testProduct = _mapper.Map<Product>(dto);
            ProductValidator validator = new ProductValidator();
            ValidationResult valResult = validator.Validate(testProduct);

            if (!valResult.IsValid)
            {
                foreach (var error in valResult.Errors)
                {
                    _logger.LogError(error.ToString());
                }
                return BadRequest(valResult.Errors);
            }
            var command = new CreateProductCommand
            {
                CompanyId = dto.CompanyId,
                ProductName = dto.ProductName,
                StartPrice = dto.StartPrice,
                FinalTime = dto.FinalTime
            };

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound("Company not found!");
            }

            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }   
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Get all products");
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            _logger.LogInformation($"Get product with id {id}");
            var query = new GetProductByIDQuery
            {
                ProductId = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
        [HttpGet("{id}/rating")]
        public async Task<IActionResult> GetProductRating(int id)
        {
            _logger.LogInformation($"Get product rating with id {id}");
            var query = new GetProductRatingQuery
            {
                ProductID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/Product/pageNumber/{pageNumber}/index/{index}")]
        public async Task<IActionResult> GetProductByPage(int pageNumber, int index)
        {
            _logger.LogInformation($"Get products by page");
            var query = new GetProductsByPageQuery
            {
                PageNumber = pageNumber,
                Index = index
            };
            var result = await _mediator.Send(query);
           
            if (result.Count == 0)
            {
                _logger.LogInformation($"Page no {pageNumber} not found");
                return NotFound("Page not found!");
            }
            return Ok(result);
        }

        [HttpGet("/api/Product/{id}/reviews")]
        public async Task<IActionResult> GetProductReviews(int id)
        {
            _logger.LogInformation($"Get reviews for product with id {id}");
            var query = new GetProductReviewsQuery
            {
                ProductID = id
            };
            var result = await _mediator.Send(query);

            
            if (result == null)
            {
                _logger.LogInformation($"Product with id {id} not found");
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/Product/{id}/reviews/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetProductReviewsByPage(int id, int pageNumber, int count)
        {
            _logger.LogInformation($"Get reviews by page for product with id {id}");
            var query = new GetProductReviewsByPageQuery
            {
                ProductID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogError($"Product with id {id} not found");
                return NotFound("Product not found!");
            }
            if (result.Count == 0)
            {
                _logger.LogError($"Page no {pageNumber} not found");
                return NotFound("Page not found!");
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProductDTO dto)
        {
            _logger.LogInformation($"Create new Product");

            var testProduct = _mapper.Map<Product>(dto);
            ProductValidator validator = new ProductValidator();
            ValidationResult valResult = validator.Validate(testProduct);

            if (!valResult.IsValid)
            {
                foreach (var error in valResult.Errors)
                {
                    _logger.LogError(error.ToString());
                }
                return BadRequest(valResult.Errors);
            }
            var command = new UpdateProductCommand
            {
                ProductId = id,
                ProductName = dto.ProductName,
                StartPrice = dto.StartPrice,
                CompanyId = dto.CompanyId,
                FinalTime = dto.FinalTime
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError($"Product with id {id} not found");
                return NotFound("Product not found!");
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }
    }
}

