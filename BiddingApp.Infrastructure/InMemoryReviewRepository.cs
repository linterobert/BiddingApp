using BiddingApp.Aplication;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure
{
    internal class InMemoryReviewRepository : IReviewRepository
    {
        private readonly List<Review> _reviews = new();

        public void Create(Review entity)
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IEnumerable<Review> entities)
        {
            throw new NotImplementedException();
        }

        public void CreateReview(Review review)
        {
            var id_uri = _reviews.Select(p => p.ReviewID);
            var id = _reviews.Count();
            while(id_uri.Contains(id))
            {
                id++;
            }
            review.ReviewID = id;
            _reviews.Add(review);
        }

        public void Delete(Review entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Review> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteReview(int id)
        {
            var review = _reviews.FirstOrDefault(p => p.ReviewID == id);
            if (review == null) throw new InvalidOperationException($"Review with id {id} not found!");

            _reviews.RemoveAll(x => x.ReviewID == review.ReviewID);
        }

        public IQueryable<Review> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Review GetReviewByID(int id)
        {
            var review = _reviews.FirstOrDefault(p => p.ReviewID == id);
            if (review == null) throw new InvalidOperationException($"Review with id {id} not found!");
            return review;
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Review entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(int id, Review review)
        {
            var _review = GetReviewByID(id);
            _review.Text = review.Text;
            _review.StarNumber = review.StarNumber;
        }
    }
}
