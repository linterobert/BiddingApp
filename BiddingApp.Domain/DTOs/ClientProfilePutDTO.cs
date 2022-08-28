using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ClientProfilePutDTO
    {
        public string ClientName { get; set; }
        public double Balance { get; set; }
        public string ProfilePhotoURL { get; set; } = "default";
    }
}
