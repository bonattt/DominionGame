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
        private static GameBoard boardInstance;

        public Queue<Player> turnOrder;
        public Dictionary<Card, int> cards;
        public GameBoard(Dictionary<Card, int> cards)
        {
            this.cards = cards;
            turnOrder = new Queue<Player>();
            AddStandardKingdomCards();
            boardInstance = this;
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
            try
            {
                return FindWinningPlayer();
            }
            catch (TieException e)
            {
                e.PrintWinners();
                throw e;
            }            
        }

        public Player FindWinningPlayer()
        {
            Player firstCounted = NextPlayer();
            Player currentHightestPlayer = firstCounted;
            TieException tie = null;
            int highestVP = currentHightestPlayer.countVictoryPoints();
            int highestMoney = currentHightestPlayer.getTotalMoney();
            do
            {
                int currentVP = turnOrder.Peek().countVictoryPoints();
                int currentMoney = turnOrder.Peek().getTotalMoney();
                if (tie != null)
                {
                    // tie.BreakTie(player) will automatically add the new player to the3 tie if he ties with the tie.
                    if (tie.BreaksTie(turnOrder.Peek()))
                    {
                        currentHightestPlayer = turnOrder.Peek();
                        highestVP = currentVP;
                        highestMoney = currentMoney;
                        tie = null;
                    }
                }
                else if (currentVP == highestVP)
                {
                    if (currentMoney > highestMoney)
                    {
                        currentHightestPlayer = turnOrder.Peek();
                        highestVP = currentVP;
                        highestMoney = currentMoney;
                    }
                    else if (currentMoney == highestMoney)
                    {
                        tie = new TieException(currentHightestPlayer, turnOrder.Peek(), currentVP, currentMoney);
                    }
                    // ELSE, nothing happens.
                }
                
                else if (currentVP > highestVP)
                {
                    currentHightestPlayer = turnOrder.Peek();
                    highestVP = currentVP;
                    highestMoney = currentMoney;
                }
                NextPlayer();
            } while (turnOrder.Peek() != firstCounted);
            
            if (tie != null)
            {
                throw tie;
            }
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

        public static GameBoard getInstance()
        {
            if (boardInstance == null)
            {
                return null; //add an exception here in the future
            }
            return boardInstance;
        }
    }
}