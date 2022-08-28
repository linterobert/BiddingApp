using BiddingApp.Aplication;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(BiddingAppContext _context) : base(_context) { }

        public async Task<Card> GetCardByCardNumber(string cardNumber)
        {
            var toReturn = await _context.Cards.Where(x => x.CardNumber == cardNumber).FirstOrDefaultAsync();
            return toReturn;
        }
    }
}
