using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class UpdateCompanyDTO
    {
        public UpdateCompanyDTO() { }
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        [Range(0.00, 9999999999.99)]
        public double CompanyBalance { get; set; }
        public string ProfilePhotoURL { get; set; }
    }
}
