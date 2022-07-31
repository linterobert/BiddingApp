using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    internal class ReviewValidator : AbstractValidator<Review>
    {
        ReviewValidator()
        {
            RuleFor(review => review.Client).NotNull();
            RuleFor(review => review.Text).NotEmpty().NotNull();
            RuleFor(review => review.StarNumber).InclusiveBetween(0, 5);
            RuleFor(review => review.Product).NotEmpty().NotNull();
        }
    }
}
