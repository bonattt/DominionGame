using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DominionCards.KingdomCards
{
    public class MoneyLender : ActionCard
    {
        private static int ID = 21;
        public MoneyLender()
            : base(0, 0, 0, 0, 4, ID)
        {
            // TODO implement
        }
        public override void play(Player player)
        {
            ArrayList hand = player.getHand();
            for (int i = 0; i < hand.Count; i++)
            {
                Card c;
                try {
                    c = (Card) hand[i];
                } catch (InvalidCastException) {
                    continue;
                }
                if (c.getID() == 0){
                    hand.Remove(c);
                    player.money += 3;
                    return;
                }
            }
        }
    }
}
