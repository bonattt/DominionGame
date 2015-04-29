using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class GameBoard
    {
        private Queue<Player> turnOrder;
        public Dictionary<Card, int> cards;
        public GameBoard(Dictionary<Card, int> cards, Queue<Player> turnOrder)
        {
            this.turnOrder = turnOrder;
            this.cards = cards;
        }
        public void addCard(Card c)
        {
            cards.Add(c, 10);
        }
        public int getCardsLeft(Card c)
        {
            return cards[c];
        }

        public int size()
        {
            return cards.Count;
        }

        public Player NextPlayer()
        {
            return null;
        }
        public Boolean AddPlayer(Player p)
        {
            if (turnOrder.Contains(p))
            {
                Console.WriteLine("that player has already been added!");
                return false;
            }
            turnOrder.Enqueue(p);
            return true;
        }
    }
}
