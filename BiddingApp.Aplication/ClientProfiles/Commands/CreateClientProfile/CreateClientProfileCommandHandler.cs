using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.ClientProfiles.Commands.CreateClientProfile
{
    internal class CreateClientProfileCommandHandler : IRequestHandler<CreateClientProfileCommand, int>
    {
        private readonly IClientProfileRepository _clientRepository;

        public CreateClientProfileCommandHandler(IClientProfileRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<int> Handle(CreateClientProfileCommand command, CancellationToken cancellationToken)
        {
            var client = new ClientProfile(command.ClientName);
            ValidationResult validator = new ValidationResult();
            ClientProfileValidator clientValidator = new ClientProfileValidator();
            validator = clientValidator.Validate(client);
            if (validator.IsValid)
            {
                return Task.FromResult(3);
            }
            else
            {
                string error = validator.Errors.ElementAt(0).ErrorMessage;
                throw new InvalidOperationException(error);
            }
        }
    }
}
