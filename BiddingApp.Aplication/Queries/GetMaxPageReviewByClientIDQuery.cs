using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetMaxPageReviewByClientIDQuery : IRequest<int>
    {
        public int ClientID { get; set; }
        public int Index { get; set; }
    }
}
