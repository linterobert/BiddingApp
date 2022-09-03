using BiddingApp.Aplication.Queries;
using BiddingApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsByPageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetProductsByPageNumber(request.PageNumber, request.Index);
        }
    }
}
