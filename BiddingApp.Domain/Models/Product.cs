using BiddingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        double _startPrice;
        public double ActualPrice { get; set; }
        public DateTime FinalTime { get; set; }
        //TimeSpan
        public int CompanyProfileId { get; set; }

        public int? ClientProfileId { get; set; }
        public bool CashOut { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductImage> Images {get;set;}

        public static double BitConstant = 0.1;

        //title
        //description
        //url
        //id
        public Product()
        {

        }
        public Product(string productName, double price,DateTime finalTime)
        {
            ProductName = productName;
            _startPrice = price;
            FinalTime = finalTime;
            ActualPrice = price;
            CashOut = false;
            Reviews = new List<Review>();
            Images = new List<ProductImage>();
        }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Product name: {ProductName};\n";
            toReturn += $"Starting price: {_startPrice}$;\n";
            toReturn += $"Actual price: {ActualPrice}$;\n";
            toReturn += $"Final time: {FinalTime};\n";
            return toReturn;
        }
        public double StartPrice { get { return _startPrice; } set { _startPrice = value; } }

        /*
        public void MakeOffer(ClientProfile client, double offer)
        {
            if (this.OwnerID != -1)
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
        
        */
    }
}
