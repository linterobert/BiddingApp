using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BiddingAppContext _context) : base(_context) { }

        public async void ChangeOwner(int id, int clientId)
        {
            var product = GetByIdAsync(id).Result;
            product.ClientProfileId = clientId;
            await Update(product);
        }
        public async Task<Product> GetProductByID(int id)
        {
            return await _context.Products.Include(x => x.Images).Include(x => x.ClientProfile).Include(x => x.CompanyProfile).Include(x => x.Reviews).Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetActiveProducts()
        {
            return await _context.Products.Where(x => x.FinalTime.CompareTo(DateTime.Now) >= 0).OrderByDescending(x => x.FinalTime).ToListAsync();
        }
        public async Task<List<Product>> GetProductsByClientId(int clientId)
        {
            return await _context.Products.Where(x => x.ClientProfileId == clientId).Include(x => x.CompanyProfile).ToListAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(x => x.CompanyProfile).Include(x => x.ClientProfile).ToListAsync();
        }
        public async Task<List<Product>> GetProductsByCompanyId(int companyId)
        {
            return await _context.Products.Where(x => x.CompanyProfileId == companyId).Include(x => x.ClientProfile).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByPrice(double min, double max)
        {
            return await _context.Products.Where(x => x.ActualPrice >= min && x.ActualPrice <= max).ToListAsync();
        }

        public async void UpdatePrice(int id, double price)
        {
            var product = GetByIdAsync(id).Result;
            product.ActualPrice = price;
            await Update(product);
        }
        public async Task<List<Product>> GetProductsByPageNumber(int pageNumber, int elements)
        {
            var products = await _context.Products.ToListAsync();
            return products.Skip((pageNumber - 1) * elements).Take(elements).ToList();
        }
        public async Task<List<Product>> GetProductsByTime(DateTime time1, DateTime time2)
        {
            return await _context.Products.Where(x => x.FinalTime.CompareTo(time2) <= 0 && x.FinalTime.CompareTo(time1) >= 0).ToListAsync();
        }
    }
}
