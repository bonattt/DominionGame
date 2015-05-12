using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards.KingdomCards
{
    public class Bureaucrat : AttackCard
    {
        public Bureaucrat()
            : base(0, 0, 0, 0, 4, 7)
        {
            // do nothing
        }
        public override void Play(Player player)
        {
            player.getDeck().Push(new Silver());
        }
    }
}
