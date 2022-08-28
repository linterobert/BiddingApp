using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class DeleteCardCommand : IRequest<Card>
    {
        public int CardId { get; set; }
    }
}
