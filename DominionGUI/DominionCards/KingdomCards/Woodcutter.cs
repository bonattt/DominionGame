using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Woodcutter : ActionCard
    {
        public Woodcutter()
            : base(0, 2, 1, 0, 3, 30)
        {
            // TODO implement

        }
        public override void play(Player player)
        {
            Console.WriteLine("I'm a lumberjack and I'm okay!");

        }

    }
}
