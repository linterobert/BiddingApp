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
    public class GetClientReviewsQueryHandler : IRequestHandler<GetClientReviewsQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Review>> Handle(GetClientReviewsQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientId);
            if (client == null)
            {
                return null;
            }
            var reviews = await _unitOfWork.ReviewRepository.GetReviewsByClientID(request.ClientId);
            return reviews;
        }
    }
}
