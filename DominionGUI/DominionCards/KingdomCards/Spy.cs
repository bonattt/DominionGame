using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Spy : ActionCard
    {
        private static int ID = 24;
        public Spy()
            : base(1, 0, 0, 1, 4, ID)
        {
            // TODO implement
        }
        public override String ToString()
        {
            return "Spy";
        }
    }
}
