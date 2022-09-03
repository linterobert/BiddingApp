using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Queries
{
    public class GetCompanyProductsByPageQuery : IRequest<List<Product>>
    {
        public int CompanyID { get; set; }
        public int PageNumber { get; set; }
        public int Index { get; set; }
    }
}
