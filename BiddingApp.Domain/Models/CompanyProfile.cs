using BiddingApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
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
        public string IBAN { get; set; }
        public double CompanyBalance { get; set; }
        public int StrikeNumber { get; set; }
        public string ProfilePhotoURL { get; set; }
        public List<CompanyNotification> Notifications { get; set; }
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

    }
}
