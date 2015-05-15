
﻿using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DominionCards
{
    public class HumanPlayer : Player
    {

        public override ArrayList SelectCards(ArrayList cards, String name, int numCards)
        {
            SelectCardsForm form = new SelectCardsForm(cards, name, numCards);
            form.GetSelection(); // mutates ArrayList cards
            Console.WriteLine("Player finished selecting cards.");
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine("Card ID " + ((Card)cards[i]).getID() + " selected");
            }
            return cards;
        }

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
            lock (GameBoard.ActionPhaseLock)
            {
                Console.WriteLine("PLAYER: Action Phase called on player " + getNumber());
                Monitor.Wait(GameBoard.ActionPhaseLock);
                Console.WriteLine("PLAYER: Button pulse recieved.");
                Card cardPlayed = GameBoard.lastCardPlayed;
                playCard(cardPlayed);
                Monitor.PulseAll(GameBoard.ActionPhaseLock);
                Console.WriteLine("PLAYER: finished playing card, pulse sent.");
                Console.WriteLine("Playing a card with ID " + cardPlayed.getID());
            }
        }
        public override void buyPhase()
        {
            Console.WriteLine("Buy Phase called on player " + getNumber());
        }
        public override void TakeTurn()
        {
            Console.WriteLine("\nplayer" + getNumber() + " taking turn.");
            while (IsActionPhase())
            {
                actionPhase();
            }
            while (IsBuyPhase())
            {
                buyPhase();
            }

//            HumanPlayerTurn work = new HumanPlayerTurn(this);
//            Thread t = new Thread(new ThreadStart(work.Run));
//            t.Start();
        }
        public bool IsActionPhase()
        {
            if (GameBoard.AbortPhase)
            {
                GameBoard.AbortPhase = false;
                return false;
            }
            for (int i = 0; i < this.getHand().Count; i++)
            {
                Card card = (Card)this.getHand()[i];
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
                    if (this.actionsLeft() > 0)
                    {
                        return true;
                        // if you have an action card and an action, it's still your action phase.
                    }
                }
            }
            return false;
        }
        public bool IsBuyPhase()
        {
            return false;
        }

        private Card GetCardToBuy()
        {
            return null;
        }
        private Card GetCardToPlay()
        {
            return null;
        }
    }
}
