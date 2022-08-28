using BiddingApp.Aplication.Commands;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class DeleteCompanyProfileCommandHandler : IRequestHandler<DeleteCompanyProfileCommand, CompanyProfile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCompanyProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<CompanyProfile> Handle(DeleteCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyId);
            if(company == null)
            {
                return null;
            }
            _unitOfWork.CompanyProfileRepository.Delete(company);
            await _unitOfWork.Save();
            return company;
        }
    }
}
