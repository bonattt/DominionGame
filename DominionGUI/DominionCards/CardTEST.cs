using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DominionCards
{
    [TestFixture()]
    class CardTEST
    {

        [Test()]
        public void testTreasureReturnsNoVP()
        {
            Card c = new KingdomCards.Silver();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [Test()]
        public void testActionReturnsNoVP()
        {
            Card c = new KingdomCards.Village();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [Test()]
        public void testVictoryReturnsVP()
        {
            Card c = new KingdomCards.Estate();
            Assert.AreEqual(1, c.getVictoryPoints());
        }
        [Test()]
        public void testGetPriceVictoryCard()
        {
            int vPrice = 2;
            Card v = new VictoryCard(1, vPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(v.getPrice(), vPrice);
        }
        [Test()]
        public void testGetPriceTreasureCard()
        {
            int tPrice = 2;
            Card t = new TreasureCard(1, tPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(t.getPrice(), tPrice);
        }
        [Test()]
        public void testGetPriceActionCard()
        {
            int aPrice = 2;
            Card a = new ActionCard(1, 1, 1, 1, aPrice, Card.GENERIC_CARD_ID);
            Assert.AreEqual(a.getPrice(), aPrice);
        }


    }
}
