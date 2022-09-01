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
    public class CreateCompanyNotificationCommandHandler : IRequestHandler<CreateCompanyNotificationCommand, CompanyNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyNotification> Handle(CreateCompanyNotificationCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyID);
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductID);
            if (client == null || product == null)
            {
                return null;
            }

            var notification = new CompanyNotification();
            notification.CompanyId = request.CompanyID;
            notification.ProductId = request.ProductID;
            notification.Title = request.Title;
            notification.Text = request.Text;
            notification.Good = request.Good;
            notification.Created = DateTime.Now;
            notification.Seen = false;
            await _unitOfWork.CompanyNotificationRepository.Create(notification);
            await _unitOfWork.Save();
            return notification;
        }
    }
}
