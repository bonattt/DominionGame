using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class TreasureCard : Card
    {
        int value;
        public TreasureCard(int money, int price)
            : base(price)
        {
            value = money;
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
