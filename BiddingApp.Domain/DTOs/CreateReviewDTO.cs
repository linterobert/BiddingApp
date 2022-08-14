using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateReviewDTO
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int StarNumber { get; set; }
        public string Text { get; set; }
    }
}
