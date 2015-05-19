using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Thief : ActionCard
    {
        private static int ID = 25;
        public Thief()
            : base(0, 0, 0, 0, 4, ID)
        {
            // TODO implement
        }
        public override String ToString()
        {
            return "Thief";
        }
    }
}
