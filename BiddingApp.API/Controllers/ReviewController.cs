using BiddingApp.Aplication;
using BiddingApp.Domain.DTOs;
using BiddingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;

        public ReviewController(IReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var reviews = _repository.GetAll();
            var reviewsToReturn = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                reviewsToReturn.Add(new ReviewDTO(review));
            }
            return Ok(reviewsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = _repository.GetByIdAsync(id).Result;
            if (review == null)
            {
                return NotFound("Review-ul nu exista!");
            }
            return Ok(new ReviewDTO(review));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDTO dto)
        {
            Review review = new Review();

            review.StarNumber = dto.StarNumber;
            review.Text = dto.Text;
            review.PostTime = DateTime.Now;
            review.ClientId = dto.ClientId;
            review.ProductId = dto.ProductId;
           
            _repository.Create(review);

            await _repository.SaveAsync();
            return Ok(new ReviewDTO(review));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review= await _repository.GetByIdAsync(id);

            if (review == null)
            {
                return NotFound("Review-ul nu exista!");
            }

            _repository.Delete(review);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, string text, int starNumber)
        {
            var review = _repository.GetByIdAsync(id).Result;
            review.StarNumber = starNumber;
            review.Text = text;
            _repository.Update(review);
            await _repository.SaveAsync();
            return Ok(new ReviewDTO(review));
        }
    }
}
