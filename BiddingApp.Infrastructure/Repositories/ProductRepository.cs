using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BiddingAppContext _context) : base(_context) { }

        public void ChangeOwner(int id, int clientId)
        {
            var product = GetByIdAsync(id).Result;
            product.ClientProfileId = clientId;
            Update(product);
        }
        public async Task<Product> GetProductByID(int id)
        {
            return await _context.Products.Include(x => x.Images).Include(x => x.ClientProfile).Include(x => x.CompanyProfile).Include(x => x.Reviews).Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(x => x.CompanyProfile).Include(x => x. ClientProfile).ToListAsync();
        }
        public IEnumerable<Product> GetActiveProducts()
        {
            return GetAll().Result.Where(x => x.FinalTime.CompareTo(DateTime.Now) >= 0);
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByClientId(int id, int clientId)
        {
            return GetAll().Result.Where(x => x.ClientProfileId == clientId);
        }

        public IEnumerable<Product> GetProductsByCompanyId(int id, int companyId)
        {
            return GetAll().Result.Where(x => x.CompanyProfileId == companyId);
        }

        public IEnumerable<Product> GetProductsByPrice(double min, double max)
        {
            return GetAll().Result.Where(x => x.ActualPrice >= min && x.ActualPrice <= max);
        }

        public void UpdatePrice(int id, double price)
        {
            var product = GetByIdAsync(id).Result;
            product.ActualPrice = price;
            Update(product);
        }
    }
}
