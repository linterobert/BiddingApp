using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.AddFunds
{
    internal class AddFundsCommand : IRequest<double>
    {
        public int ClientID { get; set; }
        public Card Card { get; set; }
        public double Sum { get; set; }
    }
}
