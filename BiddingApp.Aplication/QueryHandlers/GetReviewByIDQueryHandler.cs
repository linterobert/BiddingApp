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
    public class GetReviewByIDQueryHandler : IRequestHandler<GetReviewByIDQuery, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Review> Handle(GetReviewByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ReviewRepository.GetByIdAsync(request.ReviewID);
        }
    }
}
