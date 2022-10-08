using BiddingApp.Aplication.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication.QueryHandlers
{
    public class GetProductRatingQueryHandler : IRequestHandler<GetProductRatingQuery, double>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductRatingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<double> Handle(GetProductRatingQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetReviews();
            var notes = reviews.Where(x => x.ProductId == request.ProductID).Select(x => x.StarNumber);
            var sum = 0.00;
            if (notes.Count() > 0)
            {
                foreach (var note in notes)
                {
                    sum += note;
                }

                sum = sum / notes.Count();
                return Math.Round(sum, 2);
            }
            else
            {
                return 0.00;
            }
        }
    }
}
