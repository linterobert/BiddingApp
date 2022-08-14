using BiddingApp.Models;
using BiddingApp.Validations;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICompanyProfileRepository _companyProfileRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, ICompanyProfileRepository companyProfileRepository)
        {
            _productRepository = productRepository;
            _companyProfileRepository = companyProfileRepository;
        }

        public Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.ProductName, command.Price, command.FinalTime);
            ValidationResult validator = new ValidationResult();
            ProductValidator productValidator = new ProductValidator();
            validator = productValidator.Validate(product);
            if (validator.IsValid)
            {
                return Task.FromResult(product.ProductId);
            }
            else
            {
                string error = validator.Errors.ElementAt(0).ErrorMessage;
                throw new InvalidOperationException(error);
            }

        }
    }
}
