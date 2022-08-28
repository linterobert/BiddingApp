using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class CreateCompanyProfileCommand : IRequest<CompanyProfile>
    {
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
    }
}
