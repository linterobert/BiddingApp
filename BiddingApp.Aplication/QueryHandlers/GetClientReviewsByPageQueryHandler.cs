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
    public class GetClientReviewsByPageQueryHandler : IRequestHandler<GetClientReviewsByPageQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientReviewsByPageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Review>> Handle(GetClientReviewsByPageQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientID);
            if (client == null)
            {
                return null;
            }

            var reviews = await _unitOfWork.ReviewRepository.GetReviewsByClientID(request.ClientID);
            return reviews.Skip((request.PageNumber - 1) * request.Index).Take(request.Index).ToList();
        }
    }
}
