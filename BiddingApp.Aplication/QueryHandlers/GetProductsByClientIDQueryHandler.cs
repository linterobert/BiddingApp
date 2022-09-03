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
    public class GetProductsByClientIDQueryHandler : IRequestHandler<GetProductsByClientIDQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsByClientIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> Handle(GetProductsByClientIDQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientID);
            return products.ProductsOwn;
        }
    }
}
