using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class CreateCardCommand : IRequest<Card>
    {
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string PIN { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ClientId { get; set; }
    }
}
