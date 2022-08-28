using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class ClientProfileDTO
    {
        public int ClientProfileId { get; set; }
        public double Balance { get; set; }
        public string ClientName { get; set; }
        public string ProfilePhotoURL { get; set; }
        public List<Card> Cards { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Product> Products { get; set; }
        public ClientProfileDTO()
        {

        }
        public ClientProfileDTO(ClientProfile dto)
        {
            ClientProfileId = dto.ClientProfileId;
            Balance = dto.Balance;
            ClientName = dto.ClientName;
            Cards = dto.Cards;
            Reviews = dto.Reviews;
            Products = dto.ProductsOwn;
        }
    }
}
