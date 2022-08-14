using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.DeleteCard
{
    internal class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, String>
    {
        private readonly IClientProfileRepository _clientRepository;
        private readonly ICardRepository _cardRepository;

        public DeleteCardCommandHandler(IClientProfileRepository clientRepository, ICardRepository cardRepository)
        {
            _clientRepository = clientRepository;
            _cardRepository = cardRepository;
        }

        public Task<String> Handle(DeleteCardCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(command.Card.CardNumber);
        }
    }
}
