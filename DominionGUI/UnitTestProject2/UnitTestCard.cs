using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using DominionCards;
using DominionCards.KingdomCards;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestCard
    {
        public void testThatCardsWorkInDictionaries()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            dict.Add(new Copper(), 1);
            dict.Add(new Village(), 2);
            Assert.AreEqual(1, dict[new Copper()]);
            Assert.AreEqual(2, dict[new Village()]);
        }
        [TestMethod]
        public void testThatAdventurerDoesThing()
        {
            Card c = new Adventurer();
            Player p = new HumanPlayer();
            p.addCardToHand(c);
            p.drawHand();
            int count = p.getHand().Count;
            c.Play(p);
            Assert.AreEqual(count + 2, p.getHand().Count);
        }
        [TestMethod]
        public void testTreasureReturnsNoVP()
        {
            Card c = new Silver();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [TestMethod]
        public void testLibrary()
        {
            Card c = new Library();
            Player p = new HumanPlayer();
            p.addCardToHand(c);
            p.drawHand();
            c.Play(p);
            Assert.AreEqual(7, p.getHand().Count);
        }
        [TestMethod]
        public void testActionReturnsNoVP()
        {
            Card c = new Village();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [TestMethod]
        public void testMoneyLenderAddsMoneyIfThereIsCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            newHand.Add(new Copper());
            p.setHand(newHand);
            p.addCardToHand(c);
            int moneyBefore = p.moneyLeft();
            p.playCard(c);
            Assert.AreEqual(moneyBefore + 3, p.moneyLeft());
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderDoesNotAddMoneyIfThereIsNoCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            p.setHand(newHand);
            p.addCardToHand(c);
            int moneyBefore = p.moneyLeft();
            p.playCard(c);
            Assert.AreEqual(moneyBefore, p.moneyLeft());
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderDoesNotRemoveNoCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderRemovesCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            newHand.Add(new Copper());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore - 1, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderOnlyRemovesOneCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Copper());
            newHand.Add(new Copper());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore - 1, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testVictoryReturnsVP()
        {
            Card c = new Estate();
            Assert.AreEqual(1, c.getVictoryPoints());
        }
        [TestMethod]
        public void testCardEquals()
        {
            Card copper = new Copper();
            Card village = new Village();
            Card smithy = new Smithy();

            Assert.AreNotEqual(copper, smithy);
            Assert.AreNotEqual(copper, village);
            Assert.AreNotEqual(village, smithy);
            Assert.AreNotEqual(smithy, copper);
            Assert.AreNotEqual(village, copper);
            Assert.AreNotEqual(smithy, village);

            Assert.AreEqual(copper, new Copper());
            Assert.AreEqual(village, new Village());
            Assert.AreEqual(smithy, new Smithy());
        }

        [TestMethod]
        public void testOtherPlayersDrawCardsOnCouncilRoom()
        {
            Dictionary<Card, int> cards = new Dictionary<Card,int>();
            GameBoard board = new GameBoard(cards);
            Card c = new CouncilRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int before = p2.getHand().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(before + 1, p2.getHand().Count);
        }

        [TestMethod]
        public void testPlayerDraws4CardsOnCouncilRoom()
        {
            Dictionary<Card, int> cards = new Dictionary<Card,int>();
            GameBoard board = new GameBoard(cards);
            Card c = new CouncilRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int before = p1.getHand().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(before + 4, p1.getHand().Count);
        }
        
    }
}
