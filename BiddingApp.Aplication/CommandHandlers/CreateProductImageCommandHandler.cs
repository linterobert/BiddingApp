using BiddingApp.Aplication.Commands;
using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.CommandHandlers
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, ProductImage>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductImageCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductImage> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            ProductImage image = new ProductImage();

            if(product != null)
            {
                image.Product = product;
                image.ProductId = request.ProductId;
                image.Description = request.Description;
                image.Title = request.Title;
                image.URL = request.URL;

                await _unitOfWork.ProductImageRepository.Create(image);
                await _unitOfWork.Save();
            }
            
            return image;
        }
    }
}
