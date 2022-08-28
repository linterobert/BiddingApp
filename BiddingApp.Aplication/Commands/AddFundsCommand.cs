using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class AddFundsCommand : IRequest<ClientProfile>
    {
        public int ClientProfileId { get; set; }
        public double Sum { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string PIN { get; set; }

    }
}
