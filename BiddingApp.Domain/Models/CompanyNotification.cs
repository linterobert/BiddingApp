using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.Models
{
    public class CompanyNotification : Notification
    {
        public CompanyNotification() : base() { }
        public int CompanyId { get; set; }
        public CompanyProfile Company { get; set; }
        public int ProductId { get; set; }
    }
}
