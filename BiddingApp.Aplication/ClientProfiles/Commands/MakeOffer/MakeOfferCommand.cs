using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.MakeOffer
{
    internal class MakeOfferCommand : IRequest<int>
    {
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
    }
}
