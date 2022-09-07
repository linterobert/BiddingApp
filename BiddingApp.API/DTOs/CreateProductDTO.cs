using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string ProductName { get; set; }
        public double StartPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public int CompanyId { get; set; }
    }
}
