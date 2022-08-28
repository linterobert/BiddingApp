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
        public double ActualPrice { get; set; }
        public DateTime FinalTime { get; set; }
        public bool CashOut { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductImage> Images {get;set;}
        public double StartPrice { get; set; }
        public int CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public int? ClientProfileId { get; set; }
        public ClientProfile? ClientProfile { get; set; }

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
            StartPrice = price;
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
            toReturn += $"Starting price: {StartPrice}$;\n";
            toReturn += $"Actual price: {ActualPrice}$;\n";
            toReturn += $"Final time: {FinalTime};\n";
            return toReturn;
        }
    }
}
