using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionCards.KingdomCards;

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
            AddStandardKingdomCards();
        }
        private void AddStandardKingdomCards()
        {
            cards.Add(new Copper(), 100);
            cards.Add(new Silver(), 50);
            cards.Add(new Gold(), 30);
            cards.Add(new Estate(), 30);
            cards.Add(new Duchy(), 15);
            cards.Add(new Province(), 10);
        }
        public GameBoard(Dictionary<Card, int> cards, Queue<Player> turnOrder)
        {
            this.turnOrder = turnOrder;
            this.cards = cards;
        }
        public virtual void addCard(Card c)
        {
            cards.Add(c, 10);
        }

        public virtual int getCardsLeft(Card c)
        {
            return cards[c];
        }

        public virtual Player NextPlayer()
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
        public virtual Player PlayGame()
        {
            while (!GameIsOver())
            {
                Player next = NextPlayer();
                next.TakeTurn(this);
            }
            return FindWinningPlayer();
        }

        public Player FindWinningPlayer()
        {
            Player firstCounted = NextPlayer();
            Player currentHightestPlayer = firstCounted;
            int highestVP = currentHightestPlayer.countVictoryPoints();
            do
            {
                int currentPlayerVP = turnOrder.Peek().countVictoryPoints();

                if (currentPlayerVP == highestVP)
                {
                    if (turnOrder.Peek().getTotalMoney() > currentHightestPlayer.getTotalMoney())
                    {
                        currentHightestPlayer = turnOrder.Peek();
                    }
                }
                if (currentPlayerVP > highestVP)
                {
                    currentHightestPlayer = turnOrder.Peek();
                    highestVP = currentPlayerVP;
                }
                NextPlayer();
            } while (turnOrder.Peek() != firstCounted);
            return currentHightestPlayer;
        }
        public virtual bool GameIsOver()
        {
            Card province = new KingdomCards.Province();
            if (!cards.ContainsKey(province))
            {
                return true;
            }

            if (cards[province] == 0)
            {
                return true;
            }
            int emptyPiles = 0;
            foreach (Card c in cards.Keys)
            {
                if (cards[c] == 0)
                {
                    emptyPiles++;
                }
            }
            if (emptyPiles >= 3)
            {
                return true;
            }
            return false;
        }
        public Dictionary<Card, int> GetCards()
        {
            return cards;
        }
    }
}