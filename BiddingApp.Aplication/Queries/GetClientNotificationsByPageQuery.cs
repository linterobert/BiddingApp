using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BiddingApp.Domain.Models;

namespace BiddingApp.Aplication.Queries
{
    public class GetClientNotificationsByPageQuery : IRequest<List<ClientNotification>>
    {
        public int ClientID { get; set; }
        public int PageNumber { get; set; }
        public int Index { get; set; }
    }
}
