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
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, Card>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Card> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetByIdAsync(request.CardId);
            if(card == null)
            {
                return card;
            }
            _unitOfWork.CardRepository.Delete(card);
            await _unitOfWork.Save();
            return card;
        }
    }
}
