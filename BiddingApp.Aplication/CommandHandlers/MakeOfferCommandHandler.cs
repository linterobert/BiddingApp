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
    public class MakeOfferCommandHandler : IRequestHandler<MakeOfferCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public MakeOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(MakeOfferCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByID(request.ProductId);
            var client = await _unitOfWork.ClientProfileRepository.GetByIdAsync(request.ClientId);
            if (product == null || client == null || product.ClientProfileId == client.ClientProfileId || client.Balance <= request.sum || product.FinalTime.CompareTo(DateTime.Now) < 0 || product.ActualPrice > request.sum)
            {
                return null;
            }
            var oldclient = product.ClientProfile;
            if(oldclient != null)
            {
                oldclient.Balance = Math.Round(oldclient.Balance + product.ActualPrice*(1-Product.BitConstant), 2);
                await _unitOfWork.ClientProfileRepository.Update(oldclient);
            }
            product.ActualPrice = Math.Round(request.sum*(1+Product.BitConstant),2);
            product.ClientProfileId = request.ClientId;
            product.ClientProfile = client;
            client.Balance = Math.Round(client.Balance - request.sum, 2);
            double x = product.FinalTime.Subtract(DateTime.Now).TotalSeconds;
            if(x <= 30)
            {
                product.FinalTime = product.FinalTime.AddMinutes(1);
            }
            await _unitOfWork.ClientProfileRepository.Update(client);
            await _unitOfWork.ProductRepository.Update(product);

            await _unitOfWork.Save();
            return product;
        }
    }
}
