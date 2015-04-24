using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DominionCards.KingdomCards
{
    public class Adventurer : ActionCard
    {
        public Adventurer() : base(0, 0, 0 ,0 , 6, 6) 
        {
            
        }
        public override void play(Player player)
        {
            player.drawHand();
            player.addCardToHand(new Woodcutter());
            player.addCardToHand(new Woodcutter());
            Console.WriteLine(player.getHand().Count);

        }
    }
}
