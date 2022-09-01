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
    public class DeleteCompanyNotificationCommandHandler : IRequestHandler<DeleteCompanyNotificationCommand, CompanyNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCompanyNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyNotification> Handle(DeleteCompanyNotificationCommand request, CancellationToken cancellationToken)
        {
            var not = await _unitOfWork.CompanyNotificationRepository.GetByIdAsync(request.Id);
            if (not == null)
            {
                return null;
            }
            _unitOfWork.CompanyNotificationRepository.Delete(not);
            await _unitOfWork.Save();
            return not;
        }
    }
}
