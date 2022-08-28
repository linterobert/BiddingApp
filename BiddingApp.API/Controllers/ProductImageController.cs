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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductImageController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> PostProductImage(CreateProductImageDTO dto)
        {
            var command = new CreateProductImageCommand
            {
                Title = dto.Title,
                Description = dto.Description,
                URL = dto.URL,
                ProductId = dto.ProductId
            };
            var result = await _mediator.Send(command);
            var toReturn = _mapper.Map<ProductImageDTO>(result);
            return Ok(toReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var query = new GetImageByIDQuery
            {
                ImageID = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("Image not found!");
            }
            var toReturn = _mapper.Map<ProductImageDTO>(result);
            return Ok(toReturn);
        }
    }
}
