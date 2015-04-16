using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DominionCards
{
    public abstract class Player
    {
        private Stack<Card> deck = new Stack<Card>();
        private ArrayList hand = new ArrayList();
        private Stack<Card> discard = new Stack<Card>();
        private Stack<Card> attack = new Stack<Card>();
        private String name;
        private int actions, buys, money;
        public Player()
        {
            for (int i = 0; i < 3; i++)
            {
                deck.Push(new KingdomCards.Estate());
            }
            for (int i = 0; i < 7; i++)
            {
                deck.Push(new KingdomCards.Copper());
            }
        }
        public Card drawCard(){
            return null;
        }
        public void endTurn()
        {
            // this method should discard remaining hand, and draw new cards, then reset actions and buys to 1.
            // TODO implement this.
        }

        public abstract void actionPhase();
        public abstract void buyPhase();

        public ArrayList getHand()
        {
            return hand;
        }
        public void setHand(ArrayList h)
        {
            hand = h; // THIS METHOD IS FOR TESTING USE
        }
        public Stack<Card> getDeck()
        {
            return deck;
        }
        public Stack<Card> getDiscard()
        {
            return discard;
        }
        public Stack<Card> getAttacks()
        {
            return attack;
        }
        public String getName()
        {
            return name;
        }
        public int actionsLeft()
        {
            return actions;
        }
        public int buysLeft()
        {
            return buys;
        }
        public int moneyLeft()
        {
            return money;
        }
        public int playCard(Card c)
        {
            // finds the card that was played in the player's hand, then removes it.
            int handSize = hand.Count;
            for (int i = 0; i < hand.Count; i++)
            {
                if (hand[i] == c)
                {
                    hand.Remove(c);
                    break;
                }
            }
            // makse sure a card was removed.
            if (handSize - 1 != hand.Count)
            {
                throw new Exception("tried to play a card not in your hand!!!"); // USE A BETTER EXCEPTION
            }

            // resolves generic card effects
            ActionCard card = (ActionCard) c;
            actions--;
            for (int i = 0; i < card.cards; i++)
            {
                hand.Add(drawCard());
            }
            actions += card.actions;
            buys += card.buys;
            money += card.money;

            return actions;
        }
    }
}
