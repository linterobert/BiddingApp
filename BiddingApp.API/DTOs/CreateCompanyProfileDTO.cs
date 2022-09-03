using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateCompanyProfileDTO
    {
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
    }
}
