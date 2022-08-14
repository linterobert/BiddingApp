using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using BiddingApp.Models;

namespace BiddingApp.Aplication.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime FinalTime { get; set; }
        public CompanyProfile company { get; set; }
    }
}
