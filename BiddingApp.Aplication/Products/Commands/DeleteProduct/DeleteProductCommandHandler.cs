using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(command.ProductId);
        }

    }
}
