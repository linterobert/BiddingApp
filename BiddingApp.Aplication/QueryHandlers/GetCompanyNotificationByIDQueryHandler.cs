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
    public class GetCompanyNotificationByIDQueryHandler : IRequestHandler<GetCompanyNotificationByIDQuery, CompanyNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyNotificationByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyNotification> Handle(GetCompanyNotificationByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CompanyNotificationRepository.GetByIdAsync(request.Id);
        }
    }
}
