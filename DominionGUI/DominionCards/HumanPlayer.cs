
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
            Console.WriteLine("Action Phase called on player " + getNumber());
            Monitor.Wait(new System.Windows.Forms.Button());
            Card cardPlayed = GameBoard.lastCardPlayed;
            Console.WriteLine("Playing a card with ID " + cardPlayed.getID());
        }
        public override void buyPhase()
        {
            Console.WriteLine("Buy Phase called on player " + getNumber());
        }
        public override void TakeTurn()
        {
            Console.WriteLine("\nplayer" + getNumber() + " taking turn.");
            HumanPlayerTurn work = new HumanPlayerTurn(this);
            Thread t = new Thread(new ThreadStart(work.Run));
            t.Start();
        }

    }
}
