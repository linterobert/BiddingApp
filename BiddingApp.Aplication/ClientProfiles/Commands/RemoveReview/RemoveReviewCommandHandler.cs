using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.RemoveReview
{
    internal class RemoveReviewCommandHandler : IRequestHandler<RemoveReviewCommand, int>
    {
        private readonly IClientProfileRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public RemoveReviewCommandHandler(IClientProfileRepository clientRepository, IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }

        public Task<int> Handle(RemoveReviewCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(command.ReviewID);
        }
    }
}
