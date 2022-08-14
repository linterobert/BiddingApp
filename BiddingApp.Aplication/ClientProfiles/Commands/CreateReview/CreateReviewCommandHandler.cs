using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateReview
{
    internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IClientProfileRepository _clientProfileRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;

        public CreateReviewCommandHandler(IClientProfileRepository clientProfileRepository, IReviewRepository reviewRepository, IProductRepository productRepository)
        {
            _clientProfileRepository = clientProfileRepository;
            _reviewRepository = reviewRepository;
            _productRepository = productRepository;
        }
        public Task<int> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Review(command.Text, command.Product, command.Client, command.StarNumber);
            ValidationResult validator = new ValidationResult();
            ReviewValidator reviewValidator = new ReviewValidator();
            validator = reviewValidator.Validate(review);
            if (validator.IsValid)
            {
                return Task.FromResult(review.ReviewID);
            }
            else
            {
                string error = validator.Errors.ElementAt(0).ErrorMessage;
                throw new InvalidOperationException(error);
            }
        }
    }
}
