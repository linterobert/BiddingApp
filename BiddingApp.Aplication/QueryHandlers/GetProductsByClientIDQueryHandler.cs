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
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientID);
            if(client == null)
            {
                return null;
            }
            var products = await _unitOfWork.ProductRepository.GetProductsByClientId(request.ClientID);
            return products;
        }
    }
}
