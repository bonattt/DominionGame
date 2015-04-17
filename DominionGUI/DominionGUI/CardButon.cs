using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominionCards;

namespace DominionGUI
{
    public class CardButon : Button
    {
        private Card Card;
        public bool IsInactive, ForSale;
        // is active makes the card unusable. if for sale is true, card is availible to be bought,
        //      else it is in a player's hand and can be played.
        public CardButon(Card Card) : base()
        {
            this.Card = Card;
        }

    }
}
