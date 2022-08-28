using BiddingApp.Aplication.Commands;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class CreateClientProfileCommandHandler : IRequestHandler<CreateClientProfileCommand, ClientProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientProfile> Handle(CreateClientProfileCommand request, CancellationToken cancellationToken)
        {
            var client = new ClientProfile();
            client.ClientName = request.ClientName;
            client.Balance = 0.00;
            client.Cards = new List<Card>();
            client.ProductsOwn = new List<Product>();
            client.Reviews = new List<Review>();
            client.ProfilePhotoURL = "default";

            await _unitOfWork.ClientProfileRepository.Create(client);
            await _unitOfWork.Save();

            return client;
        }
    }
}
