using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateCardDTO
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(3)]
        public string CVC { get; set; }
        [Required]
        [StringLength(4)]
        public string PIN { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ClientId { get; set; }

    }
}
