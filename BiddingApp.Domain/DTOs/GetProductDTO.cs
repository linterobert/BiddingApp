using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double StartPrice { get; set; }
        public double ActualPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public string CompanyProfileName { get; set; }
        public string? ClientProfileName { get; set; }
        public bool CashOut { get; set; }
    }
}
