using MediatR;
using BiddingApp.Domain.Models;
using BiddingApp.Aplication.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetNotificationsByClientQueryHandler : IRequestHandler<GetNotificationsByClientQuery, List<ClientNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetNotificationsByClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClientNotification>> Handle(GetNotificationsByClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientID);
            if (client == null)
            {
                return null;
            }
            var notification = client.Notifications;
            return notification;
        }
    }
}
