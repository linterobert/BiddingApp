using BiddingApp.Aplication;
using BiddingApp.Domain.Models;
using BiddingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure.Repositories
{
    internal class ClientNotificationRepository : GenericRepository<ClientNotification>, IClientNotificationRepository
    {
        public ClientNotificationRepository(BiddingAppContext _context) : base(_context) { }

        public IEnumerable<ClientNotification> GetNotificationsByClientId(int clientId)
        {
            var notifications = _context.ClientNotifications.Where(not => not.ClientId == clientId);
            return notifications;
        }
    }
}
