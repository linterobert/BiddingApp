using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class UpdateCompanyDTO
    {
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public string ProfilePhotoURL { get; set; }
        public UpdateCompanyDTO()
        {

        }
    }
}
