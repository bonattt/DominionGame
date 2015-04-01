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
        public void testGetPriceVictoryCard()
        {
            int vPrice = 2;
            Card v = new VictoryCard(1, vPrice);
            Assert.AreEqual(v.getPrice(), vPrice);
        }
        [Test()]
        public void testGetPriceTreasureCard()
        {
            int tPrice = 2;
            Card t = new TreasureCard(1, tPrice);
            Assert.AreEqual(t.getPrice(), tPrice);
        }
        [Test()]
        public void testGetPriceActionCard()
        {
            int aPrice = 2;
            Card a = new ActionCard(1, 1, 1, 1, aPrice);
            Assert.AreEqual(a.getPrice(), aPrice);
        }
    }
}
