using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public abstract class TreasureCard : Card
    {
        public int value;
        public TreasureCard(int money, int price, int idNumb)
            : base(price, idNumb)
        {
            value = money;
        }
        public override void Play(Player p)
        {
            // TODO implement this
        }
        public override int getVictoryPoints()
        {
            return 0;
        }
        public int getValue()
        {
            Console.WriteLine("returning value of treasure card");
            return value;
        }
        public override bool IsTreasure()
        {
            return true;
        }

        public int money { get; set; }
    }
}
