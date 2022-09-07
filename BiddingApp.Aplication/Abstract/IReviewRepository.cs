using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<Review> GetReviewByProductIDandClientID(int productID, int clientID);
        Task<List<Review>> GetReviews();
        Task<List<Review>> GetReviewsByClientID(int clientID);
    }
}
