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
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            Review review = new Review();
            var check = await _unitOfWork.ReviewRepository.GetReviewByProductIDandClientID(request.ProductId, request.ClientId);
            if(check != null)
            {
                return null;
            }
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientId);
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (client != null && product != null)
            {
                review.StarNumber = request.StarNumber;
                review.Text = request.Text;
                review.PostTime = DateTime.Now;
                review.ClientId = request.ClientId;
                review.ProductId = request.ProductId;
                review.Product = product;
                review.ClientProfile = client;

                await _unitOfWork.ReviewRepository.Create(review);

                await _unitOfWork.Save();
            }
            else
            {
                return null;
            }
            return review;
        }
    }
}
