using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{//companyprofile
    internal sealed class CompanyProfile : ICloneable
    {
        string _companyName;
        string _IBAN;
        double _companyBalance;
        List<Product> _products;


        public int StrikeNumber { get; set; }
        public CompanyProfile(string companyName, string iBAN)
        {
            _companyName = companyName;
            _IBAN = iBAN;
            _products = new List<Product>();
            StrikeNumber = 0;
            _companyBalance = 0;
        }
        public override string ToString()
        {
            string toReturn = "";
            toReturn += $"Company name: {CompanyName};\n";
            toReturn += $"IBAN: {_IBAN};\n";
            toReturn += $"Balance: {_companyBalance};\n";
            for (int i = 0; i < _products.Count; i++)
            {
                toReturn += $"\nProduct no {i + 1}:\n";
                toReturn += _products[i].ToString();
            }
            return toReturn;
        }
        public string CompanyName { get { return _companyName; } }
        public String IBAN { get { return _IBAN; } set { _IBAN = value; } }
        public double CompanyBalance { get { return _companyBalance; } set { _companyBalance = value; } }
        public void AddProduct(Product product)
        {
            if (StrikeNumber < 3) this._products.Add(product);
            else Console.WriteLine("Your account was banned!");
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
                        Console.WriteLine("You don't have this product!");
                    }
                    else
                    {
                        if (!(product.FinalTime.CompareTo(DateTime.Now) < 0))
                        {
                            Console.WriteLine("This item is still in time!");
                        }
                        else
                        {
                            Console.WriteLine("You already take the money from this product");
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


    }
}
