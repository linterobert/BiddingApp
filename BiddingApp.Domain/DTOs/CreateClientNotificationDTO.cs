using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class CreateClientNotificationDTO
    {
        public CreateClientNotificationDTO() { }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public bool Good { get; set; }
       
    }
}
