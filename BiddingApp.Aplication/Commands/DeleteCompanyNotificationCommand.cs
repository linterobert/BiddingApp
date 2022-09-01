using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Commands
{
    public class DeleteCompanyNotificationCommand : IRequest<CompanyNotification>
    {
        public int Id { get; set; }
    }
}
