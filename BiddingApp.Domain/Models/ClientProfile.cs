using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{//fluentvalidation
    public sealed class ClientProfile
    {
        public int ClientProfileId { get; set; }
        public List<Product> ProductsOwn { get; set; }
        public double Balance { get; set; }
        public List<Card> Cards { get; set; }
        public string ClientName { get; set; }
        public List<Review> Reviews { get; set; }
        public string ProfilePhotoURL { get; set; }
        public ClientProfile()
        {

        }
        public ClientProfile(string clientName)
        {
            Balance = 0.00;
            ProductsOwn = new List<Product>();
            Cards = new List<Card>();
            ClientName = clientName;
            Reviews = new List<Review>();
        }
        public override string ToString()
        {
            String toReturn = "";
            toReturn += $"Client Name: {ClientName}\n";
            toReturn += $"Balance: {Balance}\n";
            toReturn += "Client cards: \n";
            return toReturn;
        }

    }
        
}