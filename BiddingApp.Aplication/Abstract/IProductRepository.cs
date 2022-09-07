using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductByID(int id);
        Task<List<Product>> GetActiveProducts();
        Task<List<Product>> GetProductsByPrice(double min, double max);
        Task<List<Product>> GetProductsByClientId(int clientId);
        Task<List<Product>> GetProductsByCompanyId(int companyId);
        Task<List<Product>> GetProductsByTime(DateTime time1, DateTime time2);
        Task<List<Product>> GetProductsByPageNumber(int pageNumber, int elements);
        void UpdatePrice(int id, double price);
        void ChangeOwner(int id, int clientId);
    }
}
