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
        public List<Product> Products { get; set; }
        public int CompanyProfileId { get; set; }
        public string CompanyName { get; set; }
        public String IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public int StrikeNumber { get; set; }

        public CompanyProfileDTO(CompanyProfile dto)
        {
            CompanyProfileId = dto.CompanyProfileId;
            Products = dto.Products;
            CompanyName = dto.CompanyName;
            IBAN = dto.IBAN;
            CompanyBalance = dto.CompanyBalance;
            StrikeNumber = dto.StrikeNumber;
        }
    }
}
