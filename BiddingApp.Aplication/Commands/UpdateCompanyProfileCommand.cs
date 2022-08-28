using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.Models;
using MediatR;

namespace BiddingApp.Aplication.Commands
{
    public class UpdateCompanyProfileCommand : IRequest<CompanyProfile>
    {
        public int CompanyProfileId { get; set; }
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public string ProfilePhotoURL { get; set; }
    }
}
