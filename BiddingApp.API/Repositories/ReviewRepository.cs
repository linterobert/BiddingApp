using BiddingApp.API.Data;
using BiddingApp.Aplication;
using BiddingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiddingApp.API.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(BiddingAppContext context) : base(context) { }
    }
}
