using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class UpdateReviewDTO
    {
        [Required]
        public int ClientId { get; set; }
        public string Text { get; set; }
        public int StarNumber { get; set; }
    }
}
