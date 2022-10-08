using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateReviewDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Range(1,5)]
        public int StarNumber { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}
