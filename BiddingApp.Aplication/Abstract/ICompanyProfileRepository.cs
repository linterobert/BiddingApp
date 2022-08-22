using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface ICompanyProfileRepository : IGenericRepository<CompanyProfile>
    {
        void UpdateCompanyName(int id, string newName);
        void UpdateCompanyBalance(int id, double balance);
        CompanyProfile GetCompanyWithProducts(int id);
    }
}
