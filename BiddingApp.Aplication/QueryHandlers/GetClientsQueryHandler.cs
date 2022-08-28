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
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientProfile>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClientProfile>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientProfileRepository.GetAll();
        }

    }
}
