using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateClientProfileDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string ClientName { get; set; }

    }
}
