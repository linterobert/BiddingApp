using BiddingApp.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetMaxPageClientNotificationQueryHandler : IRequestHandler<GetMaxPageClientNotificationQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMaxPageClientNotificationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetMaxPageClientNotificationQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientID);
            if (client == null)
            {
                return -1;
            }
            var reviews = await _unitOfWork.ClientNotificationRepository.GetNotificationsByClientID(request.ClientID);
            if (reviews.Count() % request.Index == 0)
            {
                return reviews.Count() / request.Index;
            }
            return reviews.Count() / request.Index + 1;
        }
    }
}
