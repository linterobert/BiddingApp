using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateCard
{
    internal class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, string>
    {
        private readonly ICardRepository _cardRepository;

        public CreateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public Task<string> Handle(CreateCardCommand command, CancellationToken cancellationToken)
        {
            var card = new Card(command.CardNumber, command.CVC, command.Pin, command.ExpireDate);
            ValidationResult validator = new ValidationResult();
            CardValidator clientValidator = new CardValidator();
            validator = clientValidator.Validate(card);
            if (validator.IsValid)
            {
                return Task.FromResult(card.CardNumber);
            }
            else
            {
                string error = validator.Errors.ElementAt(0).ErrorMessage;
                throw new InvalidOperationException(error);
            }
        }
    }
}
