
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Moat : AttackCard
    {
        private static int ID = 20;
        public Moat()
            : base(2, 0, 0, 0, 2, ID)
        {
            // DONE
        }
        public override String ToString()
        {
            return "Moat";
        }

        public override void Play(Player player)
        {
            // do nothing (not ACTUALLY an attack card)
        }
        public override void MakeDelayedAttack(Player playerAttacked)
        {
            System.Windows.Forms.MessageBox.Show("You blocked an attack with a moat!!");
        }

    }
}
