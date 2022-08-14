using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public ClientProfile Client { get; set; }
        public Product Product { get; set; }
        public int StarNumber { get; set; }
        public string Text { get; set; }
    }
}
