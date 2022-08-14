using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CompanyProfiles.Commands.CreateCompanyProfile
{
    internal class CreateCompanyProfileCommand : IRequest<int>
    {
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
    }
}
