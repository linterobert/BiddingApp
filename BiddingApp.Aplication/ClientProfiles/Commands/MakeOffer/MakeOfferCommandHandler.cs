using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.MakeOffer
{
    internal class MakeOfferCommandHandler : IRequestHandler<MakeOfferCommand, int>
    {
        private readonly IClientProfileRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public MakeOfferCommandHandler(IClientProfileRepository clientRepository, IProductRepository productRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        public Task<int> Handle(MakeOfferCommand command, CancellationToken cancellationToken)
        {
            _clientRepository.UpdateBalance(command.ClientID, command.Price);
            _productRepository.UpdatePrice(command.ProductID, command.Price);
            return Task.FromResult(command.ClientID);
        }
    }
}
