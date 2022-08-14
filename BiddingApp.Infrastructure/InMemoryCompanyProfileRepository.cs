using BiddingApp.Aplication;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure
{
    internal class InMemoryCompanyProfileRepository : ICompanyProfileRepository
    {
        private readonly List<CompanyProfile> _companyProfiles = new();

        public void Create(CompanyProfile entity)
        {
            throw new NotImplementedException();
        }

        public void CreateCompany(CompanyProfile company)
        {
            var id_uri = _companyProfiles.Select(p => p.CompanyProfileId);
            var id = _companyProfiles.Count();
            while (id_uri.Contains(id))
            {
                id++;
            }
            company.CompanyProfileId = id;
            _companyProfiles.Add(company);
        }

        public void CreateRange(IEnumerable<CompanyProfile> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(CompanyProfile entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteComapnyProfile(int id)
        {
            var _company = _companyProfiles.FirstOrDefault(p => p.CompanyProfileId == id);
            if (_company == null) throw new InvalidOperationException($"Company with id {id} not found!");

            _companyProfiles.RemoveAll(x => x.CompanyProfileId == id);
        }

        public void DeleteRange(IEnumerable<CompanyProfile> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CompanyProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyProfile> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyProfile GetCompanyById(int id)
        {
            var company = _companyProfiles.FirstOrDefault(p => p.CompanyProfileId == id);
            if (company == null) throw new InvalidOperationException($"Company with id {id} not found");
            return company;
        }

        public IEnumerable<CompanyProfile> GetCompanyProfiles()
        {
            return _companyProfiles;
        }

        public CompanyProfile GetCompanyWithProducts(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCompany(int id)
        {
            var company = GetCompanyById(id);
            return company.Products;
        }

        public void PostProduct(int id, Product product)
        {
            var company = GetCompanyById(id);
            company.Products.Add(product);
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyProfile entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompanyBalance(int id, double balance)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompanyName(int id, string newName)
        {
            var company = GetCompanyById(id);
            company.CompanyName = newName;
        }
    }
}
