using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine("Action Phase called on player " + getNumber());
        }
        public override void buyPhase()
        {
            Console.WriteLine("Buy Phase called on player " + getNumber());
        }
        public override void selectToDiscard()
        {
            // TODO implement
        }
        public override void TakeTurn()
        {
            ///Console.WriteLine("player" + getNumber() + " taking turn.");
            //HumanPlayerTurn work = new HumanPlayerTurn(this);
            //Thread t = new Thread(work.ActionPhase());
        }

    }
}
