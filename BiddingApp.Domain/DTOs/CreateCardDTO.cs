using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateCardDTO
    {
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string PIN { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ClientId { get; set; }

    }
}
