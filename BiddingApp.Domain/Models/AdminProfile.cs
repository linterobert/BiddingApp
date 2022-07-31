using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{
    internal class AdminProfile : ICloneable
    {
        internal protected static List<Tuple<ClientProfile, Product>> _unresolvedReports = new List<Tuple<ClientProfile, Product>>();
        internal protected static List<Tuple<ClientProfile, Product>> _resolvedReports = new List<Tuple<ClientProfile, Product>>();
        public AdminProfile() { }
        
        public void ResolveReport(ClientProfile client, Product product, bool result)
        {
            if (result != false)
            {
                product.company.StrikeNumber += 1;
            }
            Tuple<ClientProfile, Product> x = new Tuple<ClientProfile, Product>(client, product);
            _resolvedReports.Add(x);
            _unresolvedReports.Remove(x);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
