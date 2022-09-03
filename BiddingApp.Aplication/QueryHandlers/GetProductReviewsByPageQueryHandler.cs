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
    public class GetProductReviewsByPageQueryHandler : IRequestHandler<GetProductReviewsByPageQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductReviewsByPageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Review>> Handle(GetProductReviewsByPageQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByID(request.ProductID);
            if (product == null)
            {
                return null;
            }
            var reviews = product.Reviews;
            return reviews.Skip((request.PageNumber - 1) * request.Index).Take(request.Index).ToList();
        }
    }
}
