using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.UpdateReview
{
    internal class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, int>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<int> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(command.ReviewID);
        }
    }
}
