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
    public class GetCompanyNotificationsByPageNumberQueryHandler : IRequestHandler<GetCompanyNotificationsByPageNumberQuery, List<CompanyNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyNotificationsByPageNumberQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CompanyNotification>> Handle(GetCompanyNotificationsByPageNumberQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetCompanyWithProducts(request.CompanyID);
            if (company == null)
            {
                return null;
            }
            var notifications = company.Notifications;
            return notifications.Skip((request.PageNumber - 1) * request.Index).Take(request.Index).ToList();
        }
    }
}
