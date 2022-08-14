using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CashOut
{
    internal class CashOutCommandHandler : IRequestHandler<CashOutCommand, double>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IClientProfileRepository _clientProfileRepository;

        public CashOutCommandHandler(ICardRepository cardRepository, IClientProfileRepository clientProfileRepository)
        {
            _cardRepository = cardRepository;
            _clientProfileRepository = clientProfileRepository;
        }

        public Task<double> Handle(CashOutCommand command, CancellationToken cancellationToken)
        {
            var oldCard = _cardRepository.GetCardByCardNumber(command.Card.CardNumber);
            if (oldCard.CardNumber == command.Card.CardNumber
                && oldCard.ExpireDate.CompareTo(command.Card.ExpireDate) == 0
                && oldCard.Pin == command.Card.Pin
                && oldCard.CVC == command.Card.CVC)
            {
                return Task.FromResult(command.Sum);
            }
            throw new InvalidOperationException("We can't find this card!");
        }
    }
}
