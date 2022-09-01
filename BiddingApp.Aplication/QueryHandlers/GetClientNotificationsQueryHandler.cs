using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetClientNotificationsQueryHandler : IRequestHandler<GetClientNotificationsQuery, List<ClientNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientNotificationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ClientNotification>> Handle(GetClientNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientNotificationRepository.GetAll();
        }
    }
}
