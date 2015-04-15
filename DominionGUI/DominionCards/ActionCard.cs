using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class ActionCard : Card
    {
        int cards, money, buys, actions;
        public ActionCard(int extraCards, int extraMoney, int extraBuys, int extraActions, int price, int idNumb)
            : base(price, idNumb)
        {
            cards = extraCards;
            money = extraMoney;
            buys = extraBuys;
            actions = extraActions;
        }
        public override void play()
        {
            // TODO implement this
        }
        public override void addToDeck()
        {
            // TODO implement this
        }
        public override void trash()
        {
            // TODO implement this
        }
    }
}
