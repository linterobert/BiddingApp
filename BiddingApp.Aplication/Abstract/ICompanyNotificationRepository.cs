using BiddingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Abstract
{
    public interface ICompanyNotificationRepository : IGenericRepository<CompanyNotification>
    {
        Task<List<CompanyNotification>> GetNotificationsByCompanyID(int companyID);
    }
}
