using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class GetCompanyProfileDTO
    {
        public int CompanyProfileId { get; set; }
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public int StrikeNumber { get; set; }
        public string ProfilePhotoURL { get; set; }

        public GetCompanyProfileDTO()
        {

        }
    }
}
