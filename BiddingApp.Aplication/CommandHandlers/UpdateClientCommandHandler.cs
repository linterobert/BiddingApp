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
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ClientProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientProfile> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new ClientProfile();
            client.Balance = request.Balance;
            client.ClientName = request.ClientName;
            client.ClientProfileId = request.ClientProfileId;
            client.ProfilePhotoURL = request.ProfilePhotoURL;

            await _unitOfWork.ClientProfileRepository.Update(client);
            await _unitOfWork.Save();
            return client;
        }
    }
}
