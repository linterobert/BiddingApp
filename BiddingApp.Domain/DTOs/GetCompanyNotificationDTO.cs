using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.DTOs
{
    public class GetCompanyNotificationDTO 
    {
        GetCompanyNotificationDTO() { }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public DateTime Created { get; set; }
        public bool Good { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
