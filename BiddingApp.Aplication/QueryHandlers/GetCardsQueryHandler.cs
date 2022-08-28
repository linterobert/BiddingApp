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
    internal class GetCardsQueryHandler : IRequestHandler<GetCardsQuery, List<Card>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCardsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Card>> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CardRepository.GetAll();
        }
    }
}
