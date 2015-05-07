using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
            : base()
        {
            setNumber(1);
            // TODO implement
        }
        public HumanPlayer(int playerNumber)
            : base()
        {
            setNumber(playerNumber);
        }
        public override void actionPhase()
        {
            // TODO implement
        }
        public override void buyPhase()
        {
            // TODO implement
        }
        public override void selectToDiscard()
        {
            // TODO implement
        }
    }
}
