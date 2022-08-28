using BiddingApp.Aplication.Commands;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyId);
            Product product = new Product();
            if (company != null)
            {
                product.CompanyProfile = company;
                product.ProductName = request.ProductName;
                product.CompanyProfileId = request.CompanyId;
                product.ActualPrice = request.StartPrice;
                product.CashOut = false;
                product.FinalTime = request.FinalTime;
                product.StartPrice = request.StartPrice;
                await _unitOfWork.ProductRepository.Create(product);
                await _unitOfWork.Save();
            }
            else
            {
                return null;
            }
            return product;
        }
    }
}
