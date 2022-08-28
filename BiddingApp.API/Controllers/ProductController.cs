using AutoMapper;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
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
