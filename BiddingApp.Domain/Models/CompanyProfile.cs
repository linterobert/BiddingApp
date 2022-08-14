using BiddingApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{//companyprofile
    public sealed class CompanyProfile
    {
        public List<Product> Products { get; set; }
        public int CompanyProfileId { get; set; }
        public string CompanyName { get; set; }
        public String IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public int StrikeNumber { get; set; }
        public CompanyProfile()
        {

        }
        public CompanyProfile(string companyName, string iBAN)
        {
            CompanyName = companyName;
            IBAN = iBAN;
            Products = new List<Product>();
            StrikeNumber = 0;
            CompanyBalance = 0;
        }

        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Company name: {CompanyName};\n";
            toReturn += $"IBAN: {IBAN};\n";
            toReturn += $"Balance: {CompanyBalance};\n";
            for (int i = 0; i < Products.Count; i++)
            {
                toReturn += $"\nProduct no {i + 1}:\n";
                toReturn += Products[i].ToString();
            }
            return toReturn;
        }

        /*
        public void AddProduct(Product product)
        {
            if (StrikeNumber < 3) this._productsID.Add(product.ProductId);
            else
            {
                var exception = new ModelException("Your account was banned!");
                throw exception;
            }
        }
        public void CashOut(Product product)
        {
            if (StrikeNumber < 3)
            {
                if (product.CashOut == false && product.FinalTime.CompareTo(DateTime.Now) < 0 && product.Owner != null && this._products.Contains(product))
                {
                    _companyBalance += product.ActualPrice/110*100;
                    product.CashOut = true;
                    Console.WriteLine("Cash out successfully");
                }
                else
                {
                    if (!this._products.Contains(product))
                    {
                        var exception = new ModelException("You don't have this product!");
                        throw exception;
                    }
                    else
                    {
                        if (!(product.FinalTime.CompareTo(DateTime.Now) < 0))
                        {
                            var exception = new ModelException("This item is still in time!");
                            throw exception;
                        }
                        else
                        {
                            var exception = new ModelException("You already take the money from this product!");
                            throw exception;
                        }
                    }
                }
            }
            else Console.WriteLine("Your account was banned!");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        */
    }
}
