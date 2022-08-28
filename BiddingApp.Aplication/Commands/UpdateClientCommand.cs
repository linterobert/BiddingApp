using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class UpdateClientCommand : IRequest<ClientProfile>
    {
        public int ClientProfileId { get; set; }
        public string ClientName { get; set; }
        public double Balance { get; set; }
        public string ProfilePhotoURL { get; set; }
    }
}
