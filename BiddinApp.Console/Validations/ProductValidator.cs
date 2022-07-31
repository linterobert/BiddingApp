using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    internal class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.StartPrice).Must(x => x > 0.00);
            RuleFor(product => product.company).NotNull();
            RuleFor(product => product.ProductName).NotEmpty().NotNull();
            RuleFor(product => product.FinalTime).GreaterThan(product => product.PostTime);
        }
    }
}
