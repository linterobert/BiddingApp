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
    public class CreateClientNotificationCommandHandler : IRequestHandler<CreateClientNotificationCommand, ClientNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateClientNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ClientNotification> Handle(CreateClientNotificationCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientID);
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductID);
            if(client == null || product == null)
            {
                return null;
            }

            var notification = new ClientNotification();
            notification.ClientId = request.ClientID;
            notification.ProductId = request.ProductID;
            notification.Title = request.Title;
            notification.Text = request.Text;
            notification.Good = request.Good;
            notification.Created = DateTime.Now;
            notification.Seen = false;
            await _unitOfWork.ClientNotificationRepository.Create(notification);
            await _unitOfWork.Save();
            return notification;
        }
    }
}
