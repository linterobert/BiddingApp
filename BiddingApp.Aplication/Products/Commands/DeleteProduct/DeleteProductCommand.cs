using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BiddingApp.Aplication.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommand : IRequest<int>
    {
        public int ProductId { get; set; }
    }
}
