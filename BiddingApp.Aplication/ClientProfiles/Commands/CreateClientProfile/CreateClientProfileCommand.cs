using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateClientProfile
{
    internal class CreateClientProfileCommand : IRequest<int>
    {
        public string ClientName { get; set; }
    }
}
