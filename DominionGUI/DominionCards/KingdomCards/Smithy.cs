using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Smithy : ActionCard
    {

        private static int ID = 23;
        public Smithy()
            : base(3, 0, 0, 0, 4, ID)
        {
            // DONE
        }
        public override String ToString()
        {
            return "Smithy";
        }
    }
}
