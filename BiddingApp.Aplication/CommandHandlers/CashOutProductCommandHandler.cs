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
    public class CashOutProductCommandHandler : IRequestHandler<CashOutProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CashOutProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(CashOutProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByID(request.ProductId);
            var company = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyId);
            if (product.CompanyProfileId != company.CompanyProfileId || product.CashOut == true || product.FinalTime.CompareTo(DateTime.Now) < 0)
            {
                return null;
            }
            product.CashOut = true;
            company.CompanyBalance = Math.Round(company.CompanyBalance + product.ActualPrice * (1 - Product.BitConstant), 2);
            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CompanyProfileRepository.Update(company);
            await _unitOfWork.Save();
            return product;
        }
    }
}
