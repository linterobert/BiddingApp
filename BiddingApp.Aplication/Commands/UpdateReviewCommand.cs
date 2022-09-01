using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class UpdateReviewCommand : IRequest<Review>
    {
        public int ReviewId { get; set; }
        public int ClientId { get; set; }
        public string Text { get; set; }
        public int StarNumber { get; set; }
        
    }
}
