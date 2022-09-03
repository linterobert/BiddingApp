using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetClientReviewsQuery : IRequest<List<Review>>
    {
        public int ClientId { get; set; }
    }
}
