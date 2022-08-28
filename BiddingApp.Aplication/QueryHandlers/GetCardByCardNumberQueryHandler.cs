using BiddingApp.Aplication.Queries;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetCardByCardNumberQueryHandler : IRequestHandler<GetCardByCardNumberQuery, Card>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCardByCardNumberQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Card> Handle(GetCardByCardNumberQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CardRepository.GetCardByCardNumber(request.CardNumber);
        }
    }
}
