using BiddingApp.Domain.Models;
using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface IClientNotificationRepository : IGenericRepository<ClientNotification>
    {
        Task<List<ClientNotification>> GetNotificationsByClientID(int clientID);
    }
}
