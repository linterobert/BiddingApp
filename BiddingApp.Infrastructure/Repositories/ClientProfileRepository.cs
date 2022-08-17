using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ClientProfileRepository : GenericRepository<ClientProfile>, IClientProfileRepository
    {
        public ClientProfileRepository(BiddingAppContext _context) : base(_context) { }

        public IEnumerable<Product> GetProductsByClient(int id)
        {
            return _context.Products.Where(a => a.ClientProfileId == id);
        }

        public IEnumerable<Review> GetReviewsByClient(int id)
        {
            return _context.Reviews.Where(a => a.ClientId == id);
        }
        public ClientProfile GetClientProfileById(int id)
        {
            var client = _context.ClientProfiles.Include(x => x.Reviews).Include(x => x.ProductsOwn).Include(x => x.Cards).Where(x => x.ClientProfileId == id).FirstOrDefaultAsync();
            return client.Result;
        }
        public void UpdateBalance(int id, double sum)
        {
            ClientProfile client = GetByIdAsync(id).Result;
            client.Balance += sum;
            Update(client);
        }

        public void UpdateClientName(int id, string newName)
        {
            ClientProfile client = GetByIdAsync(id).Result;
            client.ClientName = newName;
            Update(client);
        }
    }
}
