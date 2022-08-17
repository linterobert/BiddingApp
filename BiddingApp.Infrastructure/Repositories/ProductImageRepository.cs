using BiddingApp.Aplication;
using BiddingApp.Domain.Models;
using BiddingApp.Infrastructure.Data;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(BiddingAppContext _context) : base(_context) { }
    }
}
