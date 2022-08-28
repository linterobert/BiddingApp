using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class AddFundsDTO
    {
        public double Sum { get; set; } 
        public string CVC { get; set; }
        public string Pin { get; set; }

        public AddFundsDTO()
        {

        }
    }
}
