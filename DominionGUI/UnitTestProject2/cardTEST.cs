using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;
using DominionCards.KingdomCards;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class cardTEST
    {
        [TestMethod]
        public void aTempTestWoodcutter()
        {
            Card c = new Woodcutter();
            Player p = new HumanPlayer();
            c.play(p);
        }
        [TestMethod]
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
            c.play(p);
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
            c.play(p);
            Assert.AreEqual(7, p.getHand().Count);
        }
        [TestMethod]
        public void testActionReturnsNoVP()
        {
            Card c = new Village();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [TestMethod]
        public void testMoneyLenderAddsSpendPoints()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            p.addCardToHand(c);
            p.drawHand();
            int buys = p.buysLeft();
            c.play(p);
            Assert.AreEqual(buys + 3, p.buysLeft());
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

        /*[TestMethod]
        public void testGetPriceVictoryCard()
        {
            int vPrice = 2;
            Card v = new VictoryCard(1, vPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(v.getPrice(), vPrice);
        }
        [TestMethod]
        public void testGetPriceTreasureCard()
        {
            int tPrice = 2;
            Card t = new TreasureCard(1, tPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(t.getPrice(), tPrice);
        }
        [TestMethod]
        public void testGetPriceActionCard()
        {
            int aPrice = 2;
            Card a = new ActionCard(1, 1, 1, 1, aPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(a.getPrice(), aPrice);
        }*/
    }
}
