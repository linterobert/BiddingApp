using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface IClientProfileRepository : IGenericRepository<ClientProfile>
    {
        Task<ClientProfile> GetClientProfileById(int id);
        Task<List<Product>> GetProductsByClient(int id);
        Task<List<Review>> GetReviewsByClient(int id);
        Task UpdateBalance(int id, double sum);
        Task UpdateClientName(int id, string newName);
    }
}
