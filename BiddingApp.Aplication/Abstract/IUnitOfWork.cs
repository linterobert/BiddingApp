using BiddingApp.Aplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public ICardRepository CardRepository { get; }
        public IClientNotificationRepository ClientNotificationRepository { get; }
        public IClientProfileRepository ClientProfileRepository { get; }
        public ICompanyProfileRepository CompanyProfileRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public ICompanyNotificationRepository CompanyNotificationRepository { get; }

        Task Save();
    }
}
