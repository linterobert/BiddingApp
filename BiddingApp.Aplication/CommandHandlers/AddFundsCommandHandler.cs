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
    public class AddFundsCommandHandler : IRequestHandler<AddFundsCommand, ClientProfile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddFundsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientProfile> Handle(AddFundsCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetCardByCardNumber(request.CardNumber);
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientProfileId);
            if( (client.Balance + request.Sum) >= 0 && client != null && card != null && card.ClientProfileId == client.ClientProfileId && card.ExpireDate.CompareTo(DateTime.Now) >= 0 && card.Pin == request.PIN && card.CVC == request.CVC)
            {
                client.Balance += request.Sum;
                await _unitOfWork.ClientProfileRepository.Update(client);
                await _unitOfWork.Save();
            }
            else
            {
                return null;
            }
            return client;
        }
    }
}
