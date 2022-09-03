using System;
using MediatR;
using BiddingApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetCompanyNotificationsByPageNumberQuery : IRequest<List<CompanyNotification>>
    {
        public int CompanyID { get; set; }
        public int PageNumber { get; set; }
        public int Index { get; set; }
    }
}
