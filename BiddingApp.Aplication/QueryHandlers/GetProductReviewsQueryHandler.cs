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
    public class GetProductReviewsQueryHandler : IRequestHandler<GetProductReviewsQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Review>> Handle(GetProductReviewsQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByID(request.ProductID);
            if (product == null)
            {
                return null;
            }
           return product.Reviews;
        }
    }
}
