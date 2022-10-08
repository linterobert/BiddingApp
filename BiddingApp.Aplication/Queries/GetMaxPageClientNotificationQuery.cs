using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BiddingApp.Aplication.Queries
{
    public class GetMaxPageClientNotificationQuery : IRequest<int>
    {
        public int ClientID { get; set; }
        public int Index { get; set; }
    }
}
