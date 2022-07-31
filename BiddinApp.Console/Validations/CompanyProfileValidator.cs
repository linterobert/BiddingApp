using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    internal class CompanyProfileValidator : AbstractValidator<CompanyProfile>
    {
        public CompanyProfileValidator()
        {
            RuleFor(company => company.CompanyName).NotNull().NotEmpty();
            RuleFor(company => company.IBAN).NotNull().NotEmpty();
            RuleFor(company => company.CompanyBalance).Must(x => x >= 0);
            RuleFor(company => company.StrikeNumber).InclusiveBetween(0, 3);
        }

    }
}
