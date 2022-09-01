using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class DeleteReviewCommand : IRequest<Review>
    {
        public int ReviewID { get; set; }
    }
}
