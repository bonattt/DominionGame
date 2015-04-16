﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;

namespace DominionCards
{

    [TestFixture()]
    class PlayerTest
    {
        [Test()]
        public void testDrawHandDiscardsOldHand()
        {
            Player p1 = new HumanPlayer();
            p1.drawHand();
            ArrayList hand = p1.getHand();
            p1.drawHand();
            Assert.AreEqual(hand, p1.getHand());
        }

        [Test()]
        public void testDrawHandDrawsFiveCards()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();

            p1.drawHand();
            Assert.AreEqual(5, hand.Count);
        }
        [Test()]
        public void testDrawHandRemovesFiveCardsFromDeck()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int initialDeck = deck.Count;

            p1.drawHand();
            Assert.AreEqual(initialDeck - 5, deck.Count);
        }

        [Test()]
        public void testPlayerStartsWithCorrectNumberOfEstates()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int numbEstates = 0;
            while (deck.Count > 0)
            {
                if (deck.Pop().getID() == 3)
                {
                    numbEstates++;
                }
            }
            Assert.AreEqual(3, numbEstates);
        }
        [Test()]
        public void testPlayerStartsWithCorrectNumberOfCopper()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int numbCopper = 0;
            while (deck.Count > 0)
            {
                if (deck.Pop().getID() == 0)
                {
                    numbCopper++;
                }
            }
            Assert.AreEqual(7, numbCopper);
        }
        [Test()]
        public void testPlayerStartsWithCorrectNumberOfCards()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            Assert.AreEqual(10, deck.Count);
        }
        [Test()]
        public void testPlayerStartsWithOnlyEstatesAndCopper()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();
            for (int i = 0; i < hand.Count; i++)
            {
                if (((Card)hand[i]).getID() != 0 && ((Card)hand[i]).getID() != 3)
                {
                    Assert.Fail();
                }
            }
        }
        [Test()]
        public void testDrawCardMakesDeckSmaller()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int initialDeckSize = deck.Count;
            p1.drawCard();
            Assert.AreEqual(initialDeckSize - 1, deck.Count);
        }
        [Test()]
        public void testDrawCardMakesHandBigger()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();

            hand.Add(new KingdomCards.Smithy());
            int initialDeckSize = hand.Count;
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);

            Assert.AreEqual(initialDeckSize + 2, hand.Count);
        }
        [Test()]
        public void playingActionCardReducesActionsByOne()
        {
            Player p1 = new HumanPlayer();
            int a = p1.actionsLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Smithy());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(a - 1, p1.actionsLeft());
        }
        [Test()]
        public void playingCardRemovesCardFromHand()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Woodcutter());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(0, p1.getHand().Count);
        }
        [Test()]
        public void playingCardWithBuysAddsBuys()
        {
            Player p1 = new HumanPlayer();
            int b = p1.buysLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Woodcutter());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(b+1, p1.buysLeft());
        }
        [Test()]
        public void playingCardWithoutBuysDoesntAddBuys()
        {
            Player p1 = new HumanPlayer();
            int b = p1.buysLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Smithy());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(b, p1.buysLeft());
        }
        [Test()]
        public void playingCardWithActionsAddsActions()
        {
            Player p1 = new HumanPlayer();
            int a = p1.actionsLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Village());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(a+1, p1.actionsLeft());
        }
        [Test()]
        public void playingCardWithMoneyAddsMoney()
        {
            Player p1 = new HumanPlayer();
            int m = p1.moneyLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Festival());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(m+2, p1.moneyLeft());
        }
        [Test()]
        public void playingCardWithoutMoneyDoesntAddMoney()
        {
            Player p1 = new HumanPlayer();
            int m = p1.moneyLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Chapel());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(m, p1.moneyLeft());
        }
        [Test()]
        public void playingCardThatDrawsCards()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = new ArrayList();
            hand.Add(new KingdomCards.Laboratory());
            p1.setHand(hand);
            printCardStats((ActionCard)hand[0]);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(2, hand.Count);
        }
        private void printCardStats(ActionCard c)
        {
            Console.WriteLine("cards drawn " + c.cards);
            Console.WriteLine("buys gianed " + c.buys);
            Console.WriteLine("acts gianed " + c.actions);
            Console.WriteLine("cash gianed " + c.money);
            Console.Read();
            Console.WriteLine();
        }
    }
}
