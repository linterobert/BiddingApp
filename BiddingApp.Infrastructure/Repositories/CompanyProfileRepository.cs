using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class CompanyProfileRepository : GenericRepository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(BiddingAppContext _context) : base(_context) { }

        public async Task<CompanyProfile> GetCompanyWithProducts(int id)
        {
            return await _context.CompanyProfiles.Include(x => x.Products).Include(x => x.Notifications).Where(x => x.CompanyProfileId == id).FirstOrDefaultAsync();
        }

        public async void UpdateCompanyBalance(int id, double balance)
        {
            var company = GetByIdAsync(id).Result;
            company.CompanyBalance += balance;
            await Update(company);
        }

        public async void UpdateCompanyName(int id, string newName)
        {
            var company = GetByIdAsync(id).Result;
            company.CompanyName = newName;
            await Update(company);
        }
    }
}
