using BiddingApp.Aplication.Commands;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Review> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetReviews();
            var review = reviews.Where(x => x.ReviewID == request.ReviewId).FirstOrDefault();
            if(review == null || review.ClientId != request.ClientId)
            {
                return null;
            }
            review.Text = request.Text;
            review.StarNumber = request.StarNumber;
            await _unitOfWork.ReviewRepository.Update(review);
            await _unitOfWork.Save();
            return review;
        }
    }
}
