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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByID(request.ProductId);
            if(product == null || product.CompanyProfileId != request.CompanyId || product.ClientProfile != null)
            {
                return null;
            }
            product.ProductName = request.ProductName;
            product.StartPrice = request.StartPrice;
            product.FinalTime = request.FinalTime;
            product.ActualPrice = request.StartPrice;
            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
            return product;
        }
    }
}
