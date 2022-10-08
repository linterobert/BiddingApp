using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetMaxPageCompanyNotificationQuery : IRequest<int>
    {
        public int CompanyID { get; set; }
        public int Index { get; set; }
    }
}
