using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CompanyProfiles.Commands.DeleteCompanyProfile
{
    internal class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, int>
    {
        private readonly ICompanyProfileRepository _companyProfileRepository;

        public DeleteCompanyCommandHandler(ICompanyProfileRepository companyProfileRepository)
        {
            _companyProfileRepository = companyProfileRepository;
        }
        public Task<int> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(command.CompanyID);
        }
    }
}
