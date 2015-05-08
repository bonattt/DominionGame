using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Library : ActionCard
    {    
        private static int ID = 16;
        public Library()
            : base(0, 0, 0, 0, 5, ID)
        {
            // TODO implement
        }
        public override void play(Player player)
        {
            int handSize = player.getHand().Count;
            while (handSize < 7)
            {
                Card c = player.getDeck().Pop();
                if (c.getID() == 0 || c.getID() == 1 || c.getID() == 2 || c.getID() == 3 || c.getID() == 4 || c.getID() == 5 || c.getID() == 32)
                {
                    player.addCardToHand(c);
                    handSize++;
                }
                else
                {
                    player.getDiscard().Add(c);
                }
            }

        }
    }
}
