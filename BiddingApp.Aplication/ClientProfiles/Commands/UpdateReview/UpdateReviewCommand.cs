using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.UpdateReview
{
    internal class UpdateReviewCommand : IRequest<int>
    {
        public int ReviewID { get; set; }
        public string Text { get; set; }
        public int StarNumber { get; set; }
    }
}
