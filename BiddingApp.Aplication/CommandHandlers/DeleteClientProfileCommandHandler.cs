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
    public class DeleteClientProfileCommandHandler : IRequestHandler<DeleteClientProfileCommand, ClientProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientProfile> Handle(DeleteClientProfileCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientProfileId);
            if(client == null)
            {
                return client;
            }
            _unitOfWork.ClientProfileRepository.Delete(client);
            await _unitOfWork.Save();
            return client;
        }
    }
}
