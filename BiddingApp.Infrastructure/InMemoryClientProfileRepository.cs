using BiddingApp.Aplication;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure
{
    internal class InMemoryClientProfileRepository : IClientProfileRepository
    {
        private readonly List<ClientProfile> _clientProfiles = new();

        public void CreateClient(ClientProfile client)
        {
            var id_uri = _clientProfiles.Select(p => p.ClientProfileId);
            var id = _clientProfiles.Count();
            while (id_uri.Contains(id))
            {
                id++;
            }
            client.ClientProfileId = id;
            _clientProfiles.Add(client);
        }

        public void DeleteClientProfile(int id)
        {
            _clientProfiles.RemoveAll(x => x.ClientProfileId == id);
        }

        public void DeleteProductFromClient(int id, Product product)
        {
            var client = GetClientById(id);
            client.ProductsOwn.RemoveAll(x => x.ProductId == product.ProductId);
        }

        public ClientProfile GetClientById(int id)
        {
            var _client = _clientProfiles.FirstOrDefault(c => c.ClientProfileId == id);
            if (_client == null) throw new InvalidOperationException($"Client with id {id} not found!");
            return _client;
        }

        public IEnumerable<ClientProfile> GetClients()
        {
            return _clientProfiles;
        }

        public IEnumerable<Product> GetProductsByClient(int id)
        {
            var client = _clientProfiles.FirstOrDefault(p => p.ClientProfileId == id);
            if (client == null) throw new InvalidOperationException($"Client with id {id} not found!");
            return client.ProductsOwn;
        }

        public IEnumerable<Review> GetReviewsByClient(int id)
        {
            var client = _clientProfiles.FirstOrDefault(p => p.ClientProfileId == id);
            if (client == null) throw new InvalidOperationException($"Client with id {id} not found!");
            return client.Reviews;
        }

        public void UpdateClientName(int id, string newName)
        {
            var client = GetClientById(id);
            client.ClientName = newName;
        }

        public void AddProduct(int id, Product product)
        {
            var client = GetClientById(id);
            client.ProductsOwn.Add(product);
        }
        public void DeleteReview(int id, Review review)
        {
            var client = GetClientById(id);
            client.Reviews.RemoveAll(x => x.ReviewID == review.ReviewID);
        }

        public void UpdateBalance(int id, double sum)
        {
            var client = GetClientById(id);
            var bal = client.Balance;
            if (bal - sum <= 0) throw new InvalidOperationException("You don't have enough founds!");
            client.Balance -= sum;
        }

        public void AddReview(int id, Review review)
        {
            var client = GetClientById(id);
            client.Reviews.Add(review);
        }

        public void DeleteCard(int id, Card card)
        {
            var client = GetClientById(id);
            client.Cards.RemoveAll(x => x.CardNumber == card.CardNumber);
        }

        public IQueryable<ClientProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientProfile> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(ClientProfile entity)
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IEnumerable<ClientProfile> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientProfile entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<ClientProfile> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public ClientProfile GetClientProfileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
