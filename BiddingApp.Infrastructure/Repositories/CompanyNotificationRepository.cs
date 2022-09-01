using BiddingApp.Aplication.Abstract;
using BiddingApp.Domain.Models;
using BiddingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure.Repositories
{
    public class CompanyNotificationRepository : GenericRepository<CompanyNotification>, ICompanyNotificationRepository
    {
        public CompanyNotificationRepository(BiddingAppContext _context) : base(_context) { }

        public async Task<List<CompanyNotification>> GetNotificationsByCompanyID(int clientId)
        {
            var notifications = await _context.CompanyNotifications.Where(not => not.CompanyId == clientId).ToListAsync();
            return notifications;
        }
    }
}
