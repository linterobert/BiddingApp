using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(review => review.Text).NotEmpty().NotNull();
            RuleFor(review => review.StarNumber).InclusiveBetween(0, 5);
        }
    }
}
