using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCards.KingdomCards
{
    public class Spy : AttackCard
    {
        private static int ID = 24;
        public Spy()
            : base(1, 0, 0, 1, 4, ID)
        {
            // TODO implement
        }

        public override void Play(Player player)
        {
            base.Play(player);
            MakeImmediateAttack(player);
        }
        public override String ToString()
        {
            return "Spy";
        }

        public override void MakeImmediateAttack(Player playerAttacked)
        {
            String str;
            if (GameBoard.getInstance().turnOrder.Peek() == playerAttacked)
            {
                str = "you have a " + playerAttacked.getDeck().Peek() + " on the top of their deck." +
                    "\n  would you like to discard it?";
            }
            else
            {
                str = "player " + playerAttacked.getNumber() + " has a " + playerAttacked.getDeck().Peek() + " on the top of their deck." +
                    "\n  would you like to discard it?";
            }
            DialogResult result1 = MessageBox.Show(str, "You played a spy", MessageBoxButtons.YesNo);
            String result = result1.ToString();

            if (result.ToLower().Equals("yes"))
            {
                playerAttacked.getDiscard().Add(playerAttacked.getDeck().Pop());
            }

        }
    }
}
