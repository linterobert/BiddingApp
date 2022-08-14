using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.Aplication;
using BiddingApp.Models;

namespace BiddingApp.Infrastructure
{
    internal class InMemoryCardRepository : ICardRepository
    {
        private readonly List<Card> _cards = new();

        public void Create(Card entity)
        {
            throw new NotImplementedException();
        }

        public void CreateCard(Card card)
        {
            _cards.Add(card);
        }

        public void CreateRange(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Card entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCard(string cardNumber)
        {
            var card = _cards.FirstOrDefault(p => p.CardNumber == cardNumber);
            if (card == null) throw new InvalidOperationException($"Card with number {cardNumber} not found!");

            _cards.Remove(card);
        }

        public void DeleteRange(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Card GetCardByCardNumber(string cardNumber)
        {
            var card = _cards.FirstOrDefault(p => p.CardNumber == cardNumber);
            if (card == null) throw new InvalidOperationException($"Card with number {cardNumber} not found!");
            return card;
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
