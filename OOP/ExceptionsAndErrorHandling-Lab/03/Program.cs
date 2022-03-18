using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    public class Program
    {
        public class Card
        {
            private string face;
            private char suit;
            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[] { "S","H","D","C" };
            public string Face
            {
                get { return this.face; }
                set
                {
                    if (validFaces.Contains(value))
                    {
                        this.face = value;
                    }
                    else
                    {
                        throw new Exception("Invalid card!");
                    }
                }
            }
            public char Suit
            {
                get { return this.suit; }
                set
                {
                    if (validSuits.Contains($"{value}"))
                    {
                        if (value=='C')
                        {
                            this.suit = '\u2663';
                        }
                        else if (value == 'D')
                        {
                            this.suit = '\u2666';
                        }
                        else if (value == 'H')
                        {
                            this.suit = '\u2665';
                        }
                        else if (value == 'S')
                        {
                            this.suit=	'\u2660' ;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid card!");
                    }
                }
            }
            public Card(string face, string suit)
            {
                Face = face;
                Suit = suit.ToCharArray()[0];
            }
            public override string ToString()
            {
                return $"[{face}{suit}]";
            }
        }
        static void Main(string[] args)
        {
            List<Card> col = new List<Card>();
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var card in input)
            {
                string[] currentCard = card.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    col.Add(new Card(currentCard[0], currentCard[1]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                Console.WriteLine(String.Join(" ",col) );
            
        }
    }
}
