using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.Models;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetClientNotificationsByPageQueryHandler : IRequestHandler<GetClientNotificationsByPageQuery, List<ClientNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientNotificationsByPageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClientNotification>> Handle(GetClientNotificationsByPageQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientID);
            if (client == null)
            {
                return null;
            }
            var notifications = client.Notifications;
            return notifications.Skip((request.PageNumber - 1) * request.Index).Take(request.Index).ToList();
        }
    }
}
