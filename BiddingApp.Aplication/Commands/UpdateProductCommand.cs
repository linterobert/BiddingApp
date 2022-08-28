using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double StartPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public int CompanyId { get; set; }
    }
}
