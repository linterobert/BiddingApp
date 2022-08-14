using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.DeleteCard
{
    internal class DeleteCardCommand : IRequest<string>
    {
        public Card Card { get; set; }
    }
}
