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
    public class GetCompanyNotificationsQueryHandler : IRequestHandler<GetCompanyNotificationQuery, List<CompanyNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyNotificationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CompanyNotification>> Handle(GetCompanyNotificationQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CompanyNotificationRepository.GetAll();
        }
    }
}
