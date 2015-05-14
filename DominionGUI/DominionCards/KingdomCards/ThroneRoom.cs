using System;
using System.Collections.Generic;
using System.Collections;
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
            ArrayList actionCards = new ArrayList();
            foreach (var card in player.getHand()){
                int id = ((Card)card).getID();
                if (id > 5 && id != 14){
                    actionCards.Add(card);
                }
            }
            ArrayList cards = player.SelectCards(actionCards);
            Card cardPlayed = (Card) cards[0];

            player.playCard(cardPlayed);
            player.addCardToHand(cardPlayed);
            player.getDiscard().Remove(cardPlayed);
            player.playCard(cardPlayed);
        }
    }
}
