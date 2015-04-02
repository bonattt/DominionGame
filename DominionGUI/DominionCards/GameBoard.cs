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
            // TODO implement
        }
        public void addCard(Card c)
        {
            // TODO implement
        }
        public int getCardsLeft(Card c)
        {
            return -1;
        }
    }
}
