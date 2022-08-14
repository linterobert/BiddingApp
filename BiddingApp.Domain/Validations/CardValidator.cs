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
            RuleFor(card => card.CVC).NotEmpty().Length(3).Matches(@"\d{3}");
            RuleFor(card => card.Pin).NotEmpty().Length(4).Matches(@"\d{4}");

        }
    }
}
