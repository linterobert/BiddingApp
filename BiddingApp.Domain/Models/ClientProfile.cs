using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Models
{//fluentvalidation
    internal sealed class ClientProfile : ICloneable
    {
        public List<Product> ProductsOwn { get; set; }
        public double Balance { get; set; }
        List<Card> _cards;
        public string ClientName { get; set; }
        List<Review> _reviews;
        public ClientProfile(string client)
        {
            Balance = 0.00;
            ProductsOwn = new List<Product>();
            _cards = new List<Card>();
            ClientName = client;
            _reviews = new List<Review>();
        }
        public override string ToString()
        {
            String toReturn = "";
            toReturn += $"Client Name: {ClientName}\n";
            toReturn += $"Balance: {Balance}\n";
            toReturn += "Client cards: \n";
            for (int i = 0; i < _cards.Count; i++)
            {
                toReturn += $"\nCard no {i + 1}:\n";
                toReturn += _cards[i].ToString();
            }
            toReturn += "Client's products:\n";
            for (int i = 0; i < ProductsOwn.Count; i++)
            {
                toReturn += $"\nProduct no {i+1}:\n";
                toReturn += ProductsOwn[i].ToString();
            }
            toReturn += "Client's reviews:\n";
            for (int i = 0; i < _reviews.Count; i++)
            {
                toReturn += $"\nReview no {i + 1}:\n";
                toReturn += _reviews[i].ToString();
            }
            return toReturn;
        }
        public void AddCard(Card newCard)
        {
            if (newCard.Owner.Equals(ClientName) && newCard.ExpireDate.CompareTo(DateTime.Now) > 0)
            {
                _cards.Add(newCard);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Card added successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (!newCard.Owner.Equals(ClientName))
                {
                    Console.WriteLine("Your profile name is different by your card name!");
                }
                else
                {
                    Console.WriteLine("Your card is out of date!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void AddMoney(Card card, double sum)
        {
            if( this._cards.Contains(card) )
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Balance += sum;
                Console.WriteLine("Successful transaction!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public void MakeOffer(Product product, double offer)
        {
            ConsoleColor x = Console.ForegroundColor;
            if (product.Owner != this)
            {
                if (product.FinalTime.CompareTo(DateTime.Now) >= 0)
                {
                    if (Balance >= offer)
                    {
                        Balance -= offer;
                        ProductsOwn.Add(product);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        product.MakeOffer(this, offer);
                        Console.WriteLine("Successful transaction!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient funds");
                    }
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This object is out of date!"); 
                }
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have this object");
            }
            Console.ForegroundColor = x;
        }
        public void RemoveCard(Card newCard)
        {
            _cards.Remove(newCard);
        }
        public void MakeReport(Product product)
        {
            AdminProfile._unresolvedReports.Add(new Tuple<ClientProfile, Product>(this, product));
        }
        public void AddReview(Product product, string message, int stars)
        {
            var products =_reviews.FindAll(x => x.Product == product).Select( x => x.Product);
            int produs = products.Count(x => x.Equals(product));
            if (produs == 0)
            {
                Review x = new Review(message, product, this, stars);
                _reviews.Add(x);
                product.Reviews.Add(x);
            }
            else
            {
                Console.WriteLine("You already add a review for this product");
            }
        }
        public void RemoveReview(Review review)
        {
            review.Product.Reviews.Remove(review);
            _reviews.Remove(review);
        }
        public void UpdateReview(Review review, string message, int stars)
        {
            RemoveReview(review);
            review.Text = message;
            review.StarNumber = stars;
            _reviews.Add(review);
            review.Product.Reviews.Add(review);
        }
        public Card FindCard(Card card)
        {
            return _cards.Find( c => c.CardNumber == card.CardNumber && c.Pin == card.Pin && c.CVC == card.CVC && c.ExpireDate == card.ExpireDate );
        }
        public Card FindCardByCardNumber(string card)
        {
            return _cards.Find(c => c.CardNumber == card);
        }
    }
}