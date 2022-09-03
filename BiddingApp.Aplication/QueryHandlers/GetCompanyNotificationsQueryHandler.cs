using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.Models;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetCompanyNotificationsQueryHandler : IRequestHandler<GetCompanyNotificationsQuery, List<CompanyNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyNotificationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CompanyNotification>> Handle(GetCompanyNotificationsQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetCompanyWithProducts(request.CompanyID);
            if (company == null)
            {
                return null;
            }
            return company.Notifications;
        }
    }
}
