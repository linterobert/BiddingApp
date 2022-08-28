using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class MakeOfferCommand : IRequest<Product>
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public double sum { get; set; }
    }
}
