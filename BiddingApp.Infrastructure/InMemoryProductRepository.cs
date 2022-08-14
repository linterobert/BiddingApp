using BiddingApp.Aplication;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        public void CreateProduct(Product product)
        {
            var id_uri = _products.Select(p => p.ProductId);
            var id = _products.Count();
            while(id_uri.Contains(id))
            {
                id++;
            }
            product.ProductId = id;
            _products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var _product = _products.FirstOrDefault(p => p.ProductId == id);
            if (_product == null) throw new InvalidOperationException($"Product with id {id} not found!");

            _products.RemoveAll(x => x.ProductId == _product.ProductId);
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            var products = _products.Find(x => x.FinalTime.CompareTo(DateTime.Now) >= 0);
            if (products == null) throw new InvalidOperationException("Can't find active products");
            return (IEnumerable<Product>)products;
        }

        public Product GetProductById(int id)
        {
            var _product = _products.FirstOrDefault(p => p.ProductId == id);
            if (_product == null) throw new InvalidOperationException($"Product with id {id} not found!");
            return _product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public IEnumerable<Product> GetProductsByPrice(double min, double max)
        {
            return _products.Where(x => x.ActualPrice >= min && x.ActualPrice <= max);
        }

        public IEnumerable<Review> GetReviewsByProduct(int id)
        {
            var _product = _products.Find(x => x.ProductId == id);
            if (_product == null) throw new InvalidOperationException($"Product with id {id} not found!");
            return _product.Reviews;
        }

        public void UpdatePrice(int id, double price)
        {
            var product = GetProductById(id);
            product.ActualPrice = price*Product.BitConstant + price;
            DateTime dateTime = DateTime.Now;
            double x = product.FinalTime.Subtract(dateTime).TotalSeconds;
            if (x <= 30)
            {
                product.FinalTime = product.FinalTime.AddMinutes(1);
            }
        }

        public void UpdateProduct(int id, Product newone)
        {
            throw new NotImplementedException();
        }
        public void ChangeOwner(int id, ClientProfile owner)
        {
            var product = GetProductById(id);
        }

        public void DeleteReview(int id, Review review)
        {
            var product = GetProductById(id);
            product.Reviews.RemoveAll(x => x.ReviewID == review.ReviewID);
        }

        public void AddReview(int id, Review review)
        {
            var product = GetProductById(id);
            product.Reviews.Add(review);
        }

        public IEnumerable<Product> GetProductsByClientId(int id, int clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCompanyId(int id, int companyId)
        {
            throw new NotImplementedException();
        }

        public void ChangeOwner(int id, int clientId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
