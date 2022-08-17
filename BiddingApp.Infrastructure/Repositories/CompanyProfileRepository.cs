using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class CompanyProfileRepository : GenericRepository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(BiddingAppContext _context) : base(_context) { }

        public CompanyProfile GetCompanyWithProducts(int id)
        {
            var company = _context.CompanyProfiles.Include(x => x.Products).Where(x => x.CompanyProfileId == id).FirstOrDefaultAsync();
            return company.Result;
        }

        public void UpdateCompanyBalance(int id, double balance)
        {
            var company = GetByIdAsync(id).Result;
            company.CompanyBalance += balance;
            Update(company);
        }

        public void UpdateCompanyName(int id, string newName)
        {
            var company = GetByIdAsync(id).Result;
            company.CompanyName = newName;
            Update(company);
        }
    }
}
