using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominionCards;
using System.Threading;

namespace DominionGUI
{
    public class CardButton : Button
    {
        public Card card;
        private bool ForSale;
        // is active makes the card unusable. if for sale is true, card is availible to be bought,
        //      else it is in a player's hand and can be played.
        public CardButton(Card card) : base()
        {
            this.card = card;
        }

        private void setCard(object sender, EventArgs e)
        {
            if (ForSale)
            {
                GameBoard.lastCardBought = card;
            }
            else
            {
                GameBoard.lastCardPlayed = card;
            }
            Monitor.PulseAll(this);
        }

    }
}
