using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    class VictoryCard : Card
    {
        int vp;
        public VictoryCard(int victoryPts, int price) : base(price)
        {
            vp = victoryPts;
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
