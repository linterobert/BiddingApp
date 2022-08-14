using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CompanyProfiles.Commands.CreateCompanyProfile
{
    internal class CreateCompanyProfileCommandHandler : IRequestHandler<CreateCompanyProfileCommand, int>
    {
        private readonly ICompanyProfileRepository _companyProfileRepository;

        public CreateCompanyProfileCommandHandler(ICompanyProfileRepository companyProfileRepository) 
        { 
            _companyProfileRepository = companyProfileRepository;
        }

        public Task<int> Handle(CreateCompanyProfileCommand command, CancellationToken cancellationToken)
        {
            var company = new CompanyProfile(command.CompanyName, command.IBAN);
            ValidationResult validator = new ValidationResult();
            CompanyProfileValidator companyValidator = new CompanyProfileValidator();
            validator = companyValidator.Validate(company);
            if (validator.IsValid)
            {
                return Task.FromResult(company.CompanyProfileId);
            }
            else
            {
                string error = validator.Errors.ElementAt(0).ErrorMessage;
                throw new InvalidOperationException(error);
            }

        }
    }
}
