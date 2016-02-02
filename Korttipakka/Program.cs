using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korttipakka
{       // create enum
    public enum Suit
    {
        SPADE,
        CLUB,
        HEART,
        DIAMONDS
    }

    public class Card
    {
        public Suit suit;
        public int value;

        public string CardName
        {
            get
            {
                switch (value)
                {
                    case 11:
                        return "Jack";
                        break;
                    case 12:
                        return "Queen";
                        break;
                    case 13:
                        return "King";
                        break;
                    case 1:
                        return "Ace";
                        break;
                    default:
                        return value.ToString();
                }
            }
        }
    }

    public class Deck
    {
        private static Random rng = new Random();  
        public Stack<Card> cards;

        public Deck(bool initialShuffle=true)
        {
            cards = new Stack<Card>(52);
            List<Card> toShuffle = new List<Card>(52);

            for(int i=1;i<14;i++)
            {
                toShuffle.Add(new Card { suit = Suit.CLUB, value = i });
                toShuffle.Add(new Card { suit = Suit.SPADE, value = i });
                toShuffle.Add(new Card { suit = Suit.HEART, value = i });
                toShuffle.Add(new Card { suit = Suit.DIAMONDS, value = i });
            }

            if (initialShuffle)
            {
                Shuffle(toShuffle);
            }

            for (int i = 0; i < toShuffle.Count; i++)
            {
                cards.Push(toShuffle[i]);
            }
        }

        private void Shuffle(List<Card> deck)
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

       

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Korttipakka");

            Deck pakka = new Deck(true);

            while(pakka.cards.Count > 0)
            {   
                // String.Format palauttaa merkkijonon 
                Card current = pakka.cards.Pop();
                Console.WriteLine(String.Format("The {0} of {1}", current.CardName, current.suit));
            }

            Console.ReadLine();
        }
    }
}
