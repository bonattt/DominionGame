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
                // add cards.
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
        public void playCard(Card c)
        {
            // TODO implement
        }
    }
}
