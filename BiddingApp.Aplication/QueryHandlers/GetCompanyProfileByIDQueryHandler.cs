using BiddingApp.Aplication.Queries;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetCompanyProfileByIDQueryHandler : IRequestHandler<GetCompanyProfileByIDQuery, CompanyProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompanyProfileByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyProfile> Handle(GetCompanyProfileByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyProfileId);
        }
    }
}
