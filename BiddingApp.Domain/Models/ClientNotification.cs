using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.Models
{
    public class ClientNotification : Notification
    {
        public ClientNotification() : base() { }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public ClientProfile Client { get; set; }
    }
}
