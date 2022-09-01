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
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Review> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(request.ReviewID);
            if(review == null)
            {
                return null;
            }
            _unitOfWork.ReviewRepository.Delete(review);
            await _unitOfWork.Save();
            return review;
        }
    }
}
