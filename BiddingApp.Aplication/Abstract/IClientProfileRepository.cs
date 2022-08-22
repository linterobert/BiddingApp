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
        ClientProfile GetClientProfileById(int id);
        IEnumerable<Product> GetProductsByClient(int id);
        IEnumerable<Review> GetReviewsByClient(int id);
        void UpdateBalance(int id, double sum);
        void UpdateClientName(int id, string newName);
    }
}
