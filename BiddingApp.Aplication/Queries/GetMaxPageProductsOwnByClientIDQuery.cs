using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BiddingApp.Aplication.Queries
{
    public class GetMaxPageProductsOwnByClientIDQuery : IRequest<int>
    {
        public int CompanyID { get; set; }
        public int Index { get; set; }
    }
}
