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
        private Stack hand = new Stack();
        private Stack deck = new Stack();
        private Stack discard = new Stack();
        private Stack attack = new Stack();
        private String name;
        private int order;
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

        public Stack getHand()
        {
            return hand;
        }
        public Stack getDeck()
        {
            return deck;
        }
        public Stack getDiscard()
        {
            return discard;
        }
        public Stack getAttacks()
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
    }
}
