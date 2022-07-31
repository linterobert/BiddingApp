using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    internal class Review
    {
        string _text;
        Product _product;
        ClientProfile _client;
        int _starNumber;
        DateTime _postTime;
        public Review(string text, Product product, ClientProfile client, int starNumber)
        {
            _text = text;
            _product = product;
            _client = client;
            _starNumber = starNumber;
            _postTime = DateTime.Now;
        }

        public Product Product { get { return _product; } }
        public String Text { get { return _text; } set { _text = value; } }
        public ClientProfile Client { get { return _client; } }
        public int StarNumber { get { return _starNumber; } set { _starNumber = value; } }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Client: {_client.ClientName};\n";
            toReturn += $"Product: {_product.ProductName};\n";
            toReturn += $"Stars : {_starNumber};\n";
            toReturn += $"Post Time: {_postTime};\n";
            toReturn += $"Text: {_text};\n";
            return toReturn;
        }

    }
}
