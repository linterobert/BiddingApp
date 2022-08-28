using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CompanyProfileDTO
    {
        public int CompanyProfileId { get; set; }
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public int StrikeNumber { get; set; }
        public CompanyProfileDTO()
        {

        }

        public CompanyProfileDTO(CompanyProfile dto)
        {
            CompanyProfileId = dto.CompanyProfileId;
            CompanyName = dto.CompanyName;
            IBAN = dto.IBAN;
            CompanyBalance = dto.CompanyBalance;
            StrikeNumber = dto.StrikeNumber;
        }
    }
}
