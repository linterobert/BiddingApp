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
    public class GetClientNotificationByIDQueryHandler : IRequestHandler<GetClientNotificationByIDQuery, ClientNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClientNotificationByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ClientNotification> Handle(GetClientNotificationByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientNotificationRepository.GetByIdAsync(request.Id);
        }
    }
}
