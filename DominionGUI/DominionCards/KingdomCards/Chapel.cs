using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCards.KingdomCards
{
    public class Chapel : ActionCard
    {
        public Chapel()
            : base(0, 0, 0, 0, 4, 10)
        {
            // TODO implement
        }

        public void textEffect()
        {
            //todo
        }
        public override void Play(Player player)
        {
            DialogResult result1 = MessageBox.Show("You played a chapel?", 
                "You played a chapel",
                MessageBoxButtons.YesNo);
        }
    }
}
