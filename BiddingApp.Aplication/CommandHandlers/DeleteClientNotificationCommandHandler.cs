using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class DeleteClientNotificationCommandHandler : IRequestHandler<DeleteClientNotificationCommand, ClientNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteClientNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ClientNotification> Handle(DeleteClientNotificationCommand request, CancellationToken cancellationToken)
        {
            var not = await _unitOfWork.ClientNotificationRepository.GetByIdAsync(request.Id);
            if(not == null)
            {
                return null;
            }
            _unitOfWork.ClientNotificationRepository.Delete(not);
            await _unitOfWork.Save();
            return not;
        }
    }
}
