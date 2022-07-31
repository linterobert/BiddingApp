using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    internal class Product : ICloneable, IEquatable<Product>
    {
        public string ProductName { get; set; }
        double _startPrice;
        public double ActualPrice { get; set; }
        DateTime _postTime;
        public DateTime FinalTime { get; set; }
        //TimeSpan
        public CompanyProfile company { get; set; }
        public ClientProfile Owner { get; set; }
        public bool CashOut { get; set; }
        public List<Review> Reviews { get; set; }
        static double BitConstant = 0.1;
        public Product(string productName, double price,DateTime finalTime, CompanyProfile company1)
        {
            ProductName = productName;
            _startPrice = price;
            _postTime = DateTime.Now;
            FinalTime = finalTime;
            company = company1;
            Owner = null;
            ActualPrice = price;
            CashOut = false;
            Reviews = new List<Review>();
        }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Product name: {ProductName};\n";
            toReturn += $"Starting price: {_startPrice}$;\n";
            toReturn += $"Actual price: {ActualPrice}$;\n";
            toReturn += $"Posting time: {_postTime};\n";
            toReturn += $"Final time: {FinalTime};\n";
            if (Owner != null)
            {
                toReturn += $"Actual owner: {Owner.ClientName};\n";
            }
            toReturn += $"Company: {company.CompanyName};\n";
            toReturn += $"Reviews: \n";
            
            for (int i = 0; i < Reviews.Count; i += 1)
            {
                toReturn += "\n";
                toReturn += $"Review no {i + 1}: \n";
                toReturn += Reviews[i].ToString();
            }
            return toReturn;
        }
        public double StartPrice { get { return _startPrice; } set { _startPrice = value; } }
        public bool CheckAvailable()
        {
            if (FinalTime.CompareTo(_postTime) > 0) return true;
            else return false;
        }
        public void MakeOffer(ClientProfile client, double offer)
        {
            if (this.Owner != null)
            {
                Owner.Balance += this.ActualPrice;
                Owner.ProductsOwn.Remove(this);
            }
            this.Owner = client;
            this.ActualPrice = offer + offer * BitConstant;
            DateTime dateTime = DateTime.Now;
            double x = FinalTime.Subtract(dateTime).TotalSeconds;
            if( x <= 30)
            {
                FinalTime = FinalTime.AddMinutes(1);
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public bool Equals(Product other)
        {
            if (other == null)
                return false;

            return this.ProductName.Equals(other.ProductName) &&
                this.StartPrice.Equals(other._startPrice) &&
                this.ActualPrice.Equals(other.ActualPrice) &&
                this.FinalTime.Equals(other.FinalTime) &&
                this.CashOut.Equals(other.CashOut);
        }
    }
}
