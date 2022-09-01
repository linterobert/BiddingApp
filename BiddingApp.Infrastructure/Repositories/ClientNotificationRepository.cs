using BiddingApp.Aplication;
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
    public class ClientNotificationRepository : GenericRepository<ClientNotification>, IClientNotificationRepository
    {
        public ClientNotificationRepository(BiddingAppContext _context) : base(_context) { }

        public async Task<List<ClientNotification>> GetNotificationsByClientID(int clientId)
        {
            var notifications = await _context.ClientNotifications.Where(not => not.ClientId == clientId).ToListAsync();
            return notifications;
        }
    }
}
