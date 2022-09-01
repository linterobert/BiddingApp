using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.Models
{
    public class CompanyNotification : Notification
    {
        public CompanyNotification() : base() { }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public CompanyProfile Company { get; set; }
        public int ProductId { get; set; }
        public DateTime Created { get; set; }
        public bool Good { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
