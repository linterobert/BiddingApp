using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class CashOutProductCommand : IRequest<Product>
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
    }
}
