using BiddingApp.API.Data;
using BiddingApp.Aplication;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.API.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(BiddingAppContext _context) : base(_context) { }

        public Card GetCardByCardNumber(string cardNumber)
        {
            return _context.Cards.Where(x => x.CardNumber == cardNumber).FirstOrDefaultAsync().Result;
        }
    }
}
