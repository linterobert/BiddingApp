using BiddingApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Validations
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(card => card.CardNumber).CreditCard();
            RuleFor(card => card.CVC).NotEmpty().Length(3).Matches(@"\d{3}").WithMessage("CVC code must have exactly 3 numbers!");
            RuleFor(card => card.Pin).NotEmpty().Length(4).Matches(@"\d{4}").WithMessage("Pin code must have exactly 4 numbers!");
            RuleFor(card => card.ExpireDate).Must(x => x.CompareTo(DateTime.Now) >= 0).WithMessage("Your card is expired!");

        }
    }
}
