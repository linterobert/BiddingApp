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
    public class GetCompanyProductsQueryHandler : IRequestHandler<GetCompanyProductsQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompanyProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> Handle(GetCompanyProductsQuery request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyProfileRepository.GetByIdAsync(request.CompanyID);
            if(company == null)
            {
                return null;
            }
            var products = await _unitOfWork.ProductRepository.GetProductsByCompanyId(request.CompanyID);
            return products;
        }
    }
}
