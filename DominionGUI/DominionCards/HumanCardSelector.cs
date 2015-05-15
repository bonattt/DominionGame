using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DominionCards
{
    public class HumanCardSelector
    {
        private HumanPlayer player;
        private HumanPlayer p1;
        public HumanCardSelector(HumanPlayer p)
        {
            player = p;
        }

        public void SelectActionCard()
        {
            Monitor.Wait(new PlayButtonSignal());

        }

    }

    public class BuyButtonSignal
    {
        public BuyButtonSignal()
        {
            // do nothing
        }
        public bool Equals(BuyButtonSignal b)
        {
            return true;
        }
    }
    public class PlayButtonSignal
    {
        public PlayButtonSignal()
        {
            // do nothing
        }
        public bool Equals(PlayButtonSignal b)
        {
            return true;
        }
    }
}
