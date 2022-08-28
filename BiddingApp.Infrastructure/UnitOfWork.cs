using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BiddingAppContext _context;

        public UnitOfWork(BiddingAppContext context, IProductRepository productRepository, ICardRepository cardRepository,
            IClientNotificationRepository clientNotificationRepository, IClientProfileRepository clientProfileRepository,
            ICompanyProfileRepository companyProfileRepository, IProductImageRepository productImageRepository,
            IReviewRepository reviewRepository)
        {
            _context = context;
            ProductImageRepository = productImageRepository;
            ProductRepository = productRepository;
            CardRepository = cardRepository;
            ClientNotificationRepository = clientNotificationRepository;
            ClientProfileRepository = clientProfileRepository;
            ReviewRepository = reviewRepository;
            CompanyProfileRepository = companyProfileRepository;

        }

        public IProductImageRepository ProductImageRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ICardRepository CardRepository { get; private set; }
        public IClientProfileRepository ClientProfileRepository { get; private set; }
        public IClientNotificationRepository ClientNotificationRepository { get; private set; }
        public ICompanyProfileRepository CompanyProfileRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
