using BiddingApp.Aplication.Queries;
using BiddingApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetImageByIDQueryHandler : IRequestHandler<GetImageByIDQuery, ProductImage>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetImageByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductImage> Handle(GetImageByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductImageRepository.GetByIdAsync(request.ImageID);
        }
    }
}
