using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CompanyProfiles.Commands.DeleteCompanyProfile
{
    internal class DeleteCompanyCommand : IRequest<int>
    {
        public int CompanyID { get; set; }
    }
}
