using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateCompanyProfileDTO
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string CompanyName { get; set; }
        [Required]
        public string IBAN { get; set; }
    }
}
