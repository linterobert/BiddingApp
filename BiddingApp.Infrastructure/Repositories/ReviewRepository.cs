using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(BiddingAppContext _context) : base(_context) { }

        public async Task<Review> GetReviewByProductIDandClientID(int productID, int clientID)
        {
            return await _context.Reviews.Where(x => x.ProductId == productID && x.ClientId == clientID).FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _context.Reviews.Include(x => x.ClientProfile).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByClientID(int clientID)
        {
            return await _context.Reviews.Include(x => x.ClientProfile).Include(x => x.Product).Where(x => x.ClientId == clientID).ToListAsync();
        }
    }
}
