using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Witch : AttackCard
    {
        private static int ID = 29;
        public Witch()
            : base(2, 0, 0, 0, 5, ID)
        {
            // TODO implement
        }

        public override void MakeImmediateAttack(Player playerAttacked)
        {
            playerAttacked.getDiscard().Add(new KingdomCards.Curse());
        }
    }
}
