using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class CardCheckBox: System.Windows.Forms.CheckBox
    {
        public Card card;
        public CardCheckBox(Card c) 
            : base()
        {
            card = c;
        }
    }
}
