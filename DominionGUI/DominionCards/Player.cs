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
        private ArrayList hand = new ArrayList();
        private ArrayList deck = new ArrayList();
        private ArrayList discard = new ArrayList();
        private ArrayList attack = new ArrayList();
        private String name;
        private int order;
        private int actions, buys, money;
        public Player()
        {
            // TODO implement this.
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
    }
}
