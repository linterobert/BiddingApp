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
    public class GetCompanyProfilesQueryHandler : IRequestHandler<GetCompanyProfilesQuery, List<CompanyProfile>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyProfilesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CompanyProfile>> Handle(GetCompanyProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CompanyProfileRepository.GetAll();
        }
    }
}
