using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class TieException : Exception
    {

        private ArrayList TiedPlayers = new ArrayList();
        private int VictoryPoints, Money;

        public TieException(Player p1, Player p2, int VPs, int money) : base() 
        {
            Money = money;
            VictoryPoints = VPs;
            TiedPlayers.Add(p1);
            TiedPlayers.Add(p2);
        }
        /**
         * returns true if player broke the tie (beat the players that tied.)
         * If the given player tied with all the players that were already tied, the player is added to the tie,
         *   but false is returned.
         * If the given player loses, false is returned.
         */
        public Boolean BreaksTie(Player p)
        {
            return false;
        }

        public int getArraySize()
        {
            return -1;
        }
    }
}
