using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    class GameBoard
    {
        private Queue<Player> turnOrder;
        private Dictionary<Card, int> cards;
        public GameBoard(Dictionary<Card, int> cards, Queue<Player> turnOrder)
        {
            this.turnOrder = turnOrder;
            this.cards = cards;
        }
        public void addCard(Card c)
        {
            cards.Add(c, 12);
        }
        public int getCardsLeft(Card c)
        {
            return cards[c];
        }
    }
}
