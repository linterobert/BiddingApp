using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetProductsByClientIDQuery : IRequest<List<Product>>
    {
        public int ClientID { get; set; }
    }
}
