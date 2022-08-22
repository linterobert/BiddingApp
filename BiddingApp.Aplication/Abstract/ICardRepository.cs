using BiddingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Aplication
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        Card GetCardByCardNumber(string cardNumber);
    }
}
