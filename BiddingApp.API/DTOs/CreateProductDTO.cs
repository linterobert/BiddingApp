using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public double StartPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public int CompanyId { get; set; }
    }
}
