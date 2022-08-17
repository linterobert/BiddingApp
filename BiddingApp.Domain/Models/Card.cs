using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int ClientProfileId { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string Pin { get; set; }
        public DateTime ExpireDate { get; set; }
        public Card()
        {

        }
        public Card(string cardNumber, string cVC, string pin, DateTime expireDate)
        {
            CardNumber = cardNumber;
            CVC = cVC;
            Pin = pin;
            ExpireDate = expireDate;
        }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Card number: {CardNumber};\n";
            toReturn += $"CVC: {CVC};\n";
            toReturn += $"Pin: {Pin};\n";
            toReturn += $"Expired date: {ExpireDate};\n";
            return toReturn;
        }
    }
}
