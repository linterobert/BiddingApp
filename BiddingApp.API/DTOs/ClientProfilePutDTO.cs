using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ClientProfilePutDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string ClientName { get; set; }
        [Range(0.00, 99999999999.99)]
        public double Balance { get; set; }
        public string ProfilePhotoURL { get; set; }
    }
}
