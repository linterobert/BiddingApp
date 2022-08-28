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
    public class GetClientProfileByIDQueryHandler : IRequestHandler<GetClientProfileByIDQuery, ClientProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientProfileByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientProfile> Handle(GetClientProfileByIDQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientProfileRepository.GetClientProfileById(request.ClientProfileId);

            return client;
        }
    }
}
