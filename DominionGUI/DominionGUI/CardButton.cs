using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominionCards;

namespace DominionGUI
{

    public class CardButton : Button
    {
        public Card card;
        public CardButton(Card card) : base()
        {
            this.card = card;
        }    
    }
}
