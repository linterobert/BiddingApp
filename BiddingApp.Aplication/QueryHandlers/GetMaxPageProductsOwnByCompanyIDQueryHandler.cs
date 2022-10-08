using BiddingApp.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetMaxPageProductsOwnByCompanyIDQueryHandler : IRequestHandler<GetMaxPageProductsOwnByCompanyIDQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMaxPageProductsOwnByCompanyIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetMaxPageProductsOwnByCompanyIDQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyID);
            if (client == null)
            {
                return -1;
            }
            var reviews = await _unitOfWork.ProductRepository.GetProductsByCompanyId(request.CompanyID);
            if (reviews.Count() % request.Index == 0)
            {
                return reviews.Count() / request.Index;
            }
            return reviews.Count() / request.Index + 1;
        }
    }
}
