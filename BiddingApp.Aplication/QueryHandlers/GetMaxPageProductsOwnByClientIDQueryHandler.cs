using BiddingApp.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetMaxPageProductsOwnByClientIDQueryHandler : IRequestHandler<GetMaxPageProductsOwnByClientIDQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMaxPageProductsOwnByClientIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetMaxPageProductsOwnByClientIDQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.CompanyID);
            if (client == null)
            {
                return -1;
            }
            var reviews = await _unitOfWork.ProductRepository.GetProductsByClientId(request.CompanyID);
            if (reviews.Count() % request.Index == 0)
            {
                return reviews.Count() / request.Index;
            }
            return reviews.Count() / request.Index + 1;
        }
    }
}
