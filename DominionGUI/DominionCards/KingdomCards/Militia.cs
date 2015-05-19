using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Militia : AttackCard
    {
        private static int ID = 18;
        public Militia()
            : base(0, 0, 0, 0, 4, ID)
        {
            // TODO implement
        }

        public override String ToString()
        {
            return "Militia";
        }
        public override void MakeDelayedAttack(Player playerAttacked)
        {
            // TODO
        }
    }
}
