using BiddingApp.Aplication.Queries;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetProductByID(request.ProductId);
        }
    }
}
