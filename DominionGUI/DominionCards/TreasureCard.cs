using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public abstract class TreasureCard : Card
    {
        int value;
        public TreasureCard(int money, int price, int idNumb)
            : base(price, idNumb)
        {
            value = money;
        }
        public override void play(Player p)
        {
            // TODO implement this
        }
        public override int getVictoryPoints()
        {
            return 0;
        }
        
        public override void addToDeck()
        {
            // TODO implement this
        }
        public override void trash()
        {
            // TODO implement this
        }
        public int getValue()
        {
            Console.WriteLine("returning value of treasure card");
            return value;
        }
    }
}
