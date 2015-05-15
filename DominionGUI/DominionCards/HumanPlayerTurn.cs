using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public class HumanPlayerTurn
    {
        private HumanPlayer player;
        private HumanPlayer p1;
        public HumanPlayerTurn(HumanPlayer p)
        {
            player = p;
        }
        public void Run()
        {
            ActionPhase();
            BuyPhase();
        }

        public void ActionPhase()
        {
            Console.WriteLine("Action Phase: Player " + player.getNumber());
        }

        public bool IsActionPhase()
        {
            if (GameBoard.AbortPhase)
            {
                GameBoard.AbortPhase = false;
                return true;
            }
            for (int i = 0; i < player.getHand().Count; i++)
            {
                Card card = (Card) player.getHand()[i];
                int id = card.getID();                    
                if (id == 0 || id == 1 || id == 2)
                {
                    return true; // treasure cards do not require an action to play. If you have any, keep playing.
                }
                else if (id == 3 || id == 4 || id == 5 || id == 14)
                {
                    continue; // if card is victory card, do nothing.
                }
                else // card is action card
                {
                    if (player.actionsLeft() > 0)
                    {
                        return true;
                        // if you have an action card and an action, it's still your action phase.
                    }
                }
            }
            return false;
        }

        public void BuyPhase(){
            Console.WriteLine("Buy Phase: Player " + player.getNumber() + "\n");
        }
    }
}
