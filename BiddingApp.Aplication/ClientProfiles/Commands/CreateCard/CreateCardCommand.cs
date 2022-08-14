using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateCard
{
    internal class CreateCardCommand : IRequest<string>
    {
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string Pin { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
