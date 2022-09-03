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
    public class GetClientProductsByPageQueryHandler : IRequestHandler<GetClientProductsByPageQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientProductsByPageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> Handle(GetClientProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientID);
            if(client == null)
            {
                return null;
            }
            var products = client.ProductsOwn;
            return products.Skip((request.PageNumber - 1) * request.Index).Take(request.Index).ToList();
        }
    }
}
