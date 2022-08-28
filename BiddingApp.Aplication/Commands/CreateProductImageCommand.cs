using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class CreateProductImageCommand : IRequest<ProductImage>
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
    }
}
