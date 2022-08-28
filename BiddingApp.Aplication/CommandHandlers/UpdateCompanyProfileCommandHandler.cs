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
    public class UpdateCompanyProfileCommandHandler : IRequestHandler<UpdateCompanyProfileCommand, CompanyProfile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCompanyProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyProfile> Handle(UpdateCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyProfileId);
            if(company == null)
            {
                return null;
            }
            company.ProfilePhotoURL = request.ProfilePhotoURL;
            company.IBAN = request.IBAN;
            company.CompanyName = request.CompanyName;
            company.CompanyBalance = request.CompanyBalance;
            await _unitOfWork.CompanyProfileRepository.Update(company);
            await _unitOfWork.Save();
            return company;
        }
    }
}
