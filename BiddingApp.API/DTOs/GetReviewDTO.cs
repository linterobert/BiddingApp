using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class GetReviewDTO
    {
        public int ReviewID { get; set; }
        public string Text { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public int StarNumber { get; set; }
        public DateTime PostTime { get; set; }
        public GetReviewDTO()
        {

        }
    }
}
