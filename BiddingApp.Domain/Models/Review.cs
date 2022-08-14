using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        string _text;
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        int _starNumber;
        public DateTime PostTime { get; set; }
        public Review()
        {

        }
        public Review(string text, Product product, ClientProfile client, int starNumber)
        {
            _text = text;
            _starNumber = starNumber;
            PostTime = DateTime.Now;
        }

        public String Text { get { return _text; } set { _text = value; } }
        public int StarNumber { get { return _starNumber; } set { _starNumber = value; } }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Stars : {_starNumber};\n";
            toReturn += $"Post Time: {PostTime};\n";
            toReturn += $"Text: {_text};\n";
            return toReturn;
        }

    }
}
