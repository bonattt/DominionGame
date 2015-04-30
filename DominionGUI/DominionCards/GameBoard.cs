using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class GameBoard
    {
        public Queue<Player> turnOrder;
        public Dictionary<Card, int> cards;
        public GameBoard(Dictionary<Card, int> cards)
        {
            this.cards = cards;
            turnOrder = new Queue<Player>();
        }
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

        public Player NextPlayer()
        {
            Player nextPlayer = turnOrder.Dequeue();
            turnOrder.Enqueue(nextPlayer);
            return nextPlayer;
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
        public void PlayGame()
        {
            int testingCutOffCounter = 0;
            while (!GameIsOver())
            {
                NextPlayer().TakeTurn();
                if (testingCutOffCounter++ >= 20)
                {
                    break;
                }
            }
        }
        public bool GameIsOver()
        {
            return false;
        }
    }
}
