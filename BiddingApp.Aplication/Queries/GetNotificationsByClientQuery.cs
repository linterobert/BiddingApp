using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetNotificationsByClientQuery : IRequest<List<ClientNotification>>
    {
        public int ClientID { get; set; }
    }
}
