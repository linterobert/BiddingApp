using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    public class ClientProfileValidator : AbstractValidator<ClientProfile>
    {
        public ClientProfileValidator()
        {
            RuleFor(client => client.Balance).GreaterThanOrEqualTo(0.00);
            RuleFor(client => client.ClientName).NotNull().NotEmpty().WithMessage("You must enter your name!");
            RuleFor(client => client.ClientName).MinimumLength(4).WithMessage("Your name must have minimum 3 letters!"); ;
        }
    }
}
