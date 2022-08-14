using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    public class Card : ICloneable
    {
        public int Id { get; set; }
        string _cardNumber;
        string _CVC;
        string _pin;
        public int ClientProfileId { get; set; }
        DateTime _expireDate;
        public Card()
        {

        }
        public Card(string cardNumber, string cVC, string pin, DateTime expireDate)
        {
            _cardNumber = cardNumber;
            _CVC = cVC;
            _pin = pin;
            _expireDate = expireDate;
        }
        public string CardNumber { get { return _cardNumber; } set { _cardNumber = value; } }
        public string CVC { get { return _CVC; } set { _CVC = value; } }
        public string Pin { get { return _pin; } set { _pin = value; } }
        public DateTime ExpireDate { get { return _expireDate; } set { _expireDate = value; } }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Card number: {_cardNumber};\n";
            toReturn += $"CVC: {_CVC};\n";
            toReturn += $"Pin: {_pin};\n";
            toReturn += $"Expired date: {ExpireDate};\n";
            return toReturn;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
