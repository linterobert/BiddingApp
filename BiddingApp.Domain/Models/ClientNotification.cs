using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.Models
{
    public class ClientNotification : Notification
    {
        public ClientNotification() : base() { }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public ClientProfile Client { get; set; }
        public DateTime Created { get; set; }
        public bool Good { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
