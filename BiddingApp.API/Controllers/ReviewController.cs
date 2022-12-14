using AutoMapper;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Commands;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ReviewController(IMediator mediator, IMapper mapper, ILogger<ReviewController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDTO dto)
        {
            _logger.LogInformation("Create review");
            if (!ModelState.IsValid)
            {
                _logger.LogError(ModelState.ToString());
                return BadRequest(ModelState);
            }
            var command = new CreateReviewCommand
            {
                ProductId = dto.ProductId,
                ClientId = dto.ClientId,
                StarNumber = dto.StarNumber,
                Text = dto.Text
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogInformation($"Client with id {dto.ClientId} already add a comm at product with id {dto.ProductId}");
                return NotFound("You already comment at this product!");
            }
            var toReturn = _mapper.Map<ReviewDTO>(result);
            return Ok(toReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            _logger.LogInformation("Ger reviews");
            var command = new GetReviewsQuery();
            var result = await _mediator.Send(command);
            var toReturn = _mapper.Map<List<GetReviewDTO>>(result);
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            _logger.LogInformation($"Get review with id {id}");
            var command = new GetReviewByIDQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            _logger.LogInformation($"Delete review with id {id}");
            var command = new DeleteReviewCommand
            {
                ReviewID = id
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                _logger.LogError($"Review with id {id} not found");
                return NotFound("Review not found!");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDTO dto)
        {
            _logger.LogInformation("Update review");
            var command = new UpdateReviewCommand
            {
                ReviewId = id,
                ClientId = dto.ClientId,
                StarNumber = dto.StarNumber,
                Text = dto.Text
            };
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound("Review not found!");
            }
            var toReturn = _mapper.Map<GetReviewDTO>(result);
            return Ok(toReturn);
        }


    }
}