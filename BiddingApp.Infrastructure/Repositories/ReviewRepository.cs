using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(BiddingAppContext context) : base(context) { }
    }
}
