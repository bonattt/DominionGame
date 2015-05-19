using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCards.KingdomCards
{
    public class Feast : ActionCard
    {
        private static int ID = 12;
        public Feast()
            : base(0, 0, 0, 0, 4, ID)
        {
            // TODO implement
        }
        public override String ToString()
        {
            return "Feast";
        }

        public override void Play(Player player)
        {
            //trash the feast
            player.getDiscard().Remove(new Feast());
            //pick a card to gain
            ArrayList buyableCards = new ArrayList();
            foreach (Card card in GameBoard.getInstance().cards.Keys)
            {
                int cost = card.getPrice();
                if (cost < 6)
                {
                    buyableCards.Add(card);
                }
            }
            if (buyableCards.Count == 0)
            {
                MessageBox.Show("You have no cards to buy with the feast!");
                return;
            }
            ArrayList cards = player.SelectCards(buyableCards, "Choose a card to gain.", 1);
            while (cards.Count > 1)
            {
                DialogResult result1 = MessageBox.Show("You may only select 1 card to gain.  Try again");
                cards = player.SelectCards(buyableCards, "Choose a card to gain.", 1);
            }
            Card cardSelected = (Card)cards[0];
            player.getDiscard().Add(cardSelected);
            GameBoard.getInstance().GetCards()[cardSelected] -= 1;


        }
        private int checkCounter;


    }
}
