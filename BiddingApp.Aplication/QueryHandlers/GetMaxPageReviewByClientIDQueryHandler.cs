using BiddingApp.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetMaxPageReviewByClientIDQueryHandler : IRequestHandler<GetMaxPageReviewByClientIDQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMaxPageReviewByClientIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetMaxPageReviewByClientIDQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientID);
            if (client == null)
            {
                return -1;
            }
            var reviews = client.Reviews;
            if(reviews.Count() % request.Index == 0)
            {
                return reviews.Count() / request.Index;
            }
            return reviews.Count()/request.Index + 1;
        }
    }
}
