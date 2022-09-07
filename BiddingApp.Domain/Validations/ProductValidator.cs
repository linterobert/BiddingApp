using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.StartPrice).Must(x => x > 0.00).WithMessage("Start price must be higher than 0$!");
            RuleFor(product => product.FinalTime).Must(x => x.CompareTo(DateTime.Now) >= 0).WithMessage("Final time must be higher then actual time!");
            RuleFor(product => product.ProductName).Must(x => x.Length >= 2 && x.Length <= 30).WithMessage("The product name must have between 2 and 30 characters!");
        }
    }
}
