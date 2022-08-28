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
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Card>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Card> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientId);
            Card card = new Card();

            if (client != null)
            {
                card.CardNumber = request.CardNumber;
                card.ClientProfileId = request.ClientId;
                card.Pin = request.PIN;
                card.CVC = request.CVC;
                card.ExpireDate = request.ExpireDate;

                await _unitOfWork.CardRepository.Create(card);
                await _unitOfWork.Save();

                return card;
            }

            return null;
        }
    }
}
