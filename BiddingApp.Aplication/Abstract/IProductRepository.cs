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
        IEnumerable<Product> GetActiveProducts();
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByPrice(double min, double max);
        IEnumerable<Product> GetProductsByClientId(int id, int clientId);
        IEnumerable<Product> GetProductsByCompanyId(int id, int companyId);
        void UpdatePrice(int id, double price);
        void ChangeOwner(int id, int clientId);
    }
}
