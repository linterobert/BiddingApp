﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.RemoveReview
{
    internal class RemoveReviewCommand : IRequest<int>
    {
        public int ReviewID { get; set; }
    }
}
