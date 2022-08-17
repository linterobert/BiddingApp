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
        public string Text { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int StarNumber { get; set; }
        public DateTime PostTime { get; set; }
        public Review()
        {

        }
        public Review(string text, Product product, ClientProfile client, int starNumber)
        {
            Text = text;
            StarNumber = starNumber;
            PostTime = DateTime.Now;
        }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Stars : {StarNumber};\n";
            toReturn += $"Post Time: {PostTime};\n";
            toReturn += $"Text: {Text};\n";
            return toReturn;
        }

    }
}
