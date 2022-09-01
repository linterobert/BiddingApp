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
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Review>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ReviewRepository.GetReviews();
        }
    }
}
