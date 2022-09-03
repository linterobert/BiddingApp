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
    public class ProductController : ControllerBase
    { 
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
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
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            var toReturn = _mapper.Map<List<GetProductDTO>>(result);
            return Ok(toReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIDQuery
            {
                ProductId = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/Product/pageNumber/{pageNumber}/index/{index}")]
        public async Task<IActionResult> GetProductByPage(int pageNumber, int index)
        {
            var query = new GetProductsByPageQuery
            {
                PageNumber = pageNumber,
                Index = index
            };
            var result = await _mediator.Send(query);

            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            return Ok(result);
        }

        [HttpGet("/api/Product/{id}/reviews")]
        public async Task<IActionResult> GetProductReviews(int id)
        {
            var query = new GetProductReviewsQuery
            {
                ProductID = id
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
        [HttpGet("/api/Product/{id}/reviews/page-number/{pageNumber}/count/{count}")]
        public async Task<IActionResult> GetProductReviewsByPage(int id, int pageNumber, int count)
        {
            var query = new GetProductReviewsByPageQuery
            {
                ProductID = id,
                PageNumber = pageNumber,
                Index = count
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Product not found!");
            }
            if (result.Count == 0)
            {
                return NotFound("Page not found!");
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProductDTO dto)
        {
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
                return NotFound("Product not found!");
            }
            var toReturn = _mapper.Map<GetProductDTO>(result);
            return Ok(toReturn);
        }
    }
}
