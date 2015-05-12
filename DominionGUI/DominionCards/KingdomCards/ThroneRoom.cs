using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCards.KingdomCards
{
    public class ThroneRoom : ActionCard
    {
        private static int ID = 26;
        public ThroneRoom()
            : base(0, 0, 0, 0, 4, ID)
        {
            // TODO implement
        }

        public override void Play(Player player)
        {
            base.Play(player);
            MessageBox.Show("do the thing", "ThroneRoom", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
