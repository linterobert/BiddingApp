using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.Models;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class CreateCompanyProfileCommandHandler : IRequestHandler<CreateCompanyProfileCommand, CompanyProfile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyProfile> Handle(CreateCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            var company = new CompanyProfile();
            company.CompanyName = request.CompanyName;
            company.IBAN = request.IBAN;
            company.ProfilePhotoURL = "default";
            company.StrikeNumber = 0;
            company.CompanyBalance = 0;
            company.Products = new List<Product>();
            company.Notifications = new List<CompanyNotification>();
            
            
            await _unitOfWork.CompanyProfileRepository.Create(company);
            await _unitOfWork.Save();

            return company;
        }
    }
}
