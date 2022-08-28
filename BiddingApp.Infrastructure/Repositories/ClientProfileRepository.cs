using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ClientProfileRepository : GenericRepository<ClientProfile>, IClientProfileRepository
    {
        public ClientProfileRepository(BiddingAppContext _context) : base(_context) { }
        public async Task<List<Product>> GetProductsByClient(int id)
        {
            return await _context.Products.Where(a => a.ClientProfileId == id).ToListAsync();
        }
        public async Task<List<Review>> GetReviewsByClient(int id)
        {
            return await _context.Reviews.Where(a => a.ClientId == id).ToListAsync();
        }
        public async Task<ClientProfile> GetClientProfileById(int id)
        {
            var client = await _context.ClientProfiles.Include(x => x.Reviews).Include(x => x.ProductsOwn).Include(x => x.Cards).Where(x => x.ClientProfileId == id).FirstOrDefaultAsync();
            return client;
        }
        public async Task UpdateBalance(int id, double sum)
        {
            var client = await GetByIdAsync(id);
            client.Balance += sum;
            Update(client);
        }
        public async Task UpdateClientName(int id, string newName)
        {
            var client = await GetByIdAsync(id);
            client.ClientName = newName;
            Update(client);
        }
    }
}
