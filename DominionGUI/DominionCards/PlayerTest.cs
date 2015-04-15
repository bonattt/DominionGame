using System;
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
        public void testPlayerStartsWithCorrectNumberOfEstates()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();
            Assert.Fail();
        }
        [Test()]
        public void testPlayerStartsWithCorrectNumberOfCopper()
        {
            Player p1 = new HumanPlayer();

            Assert.Fail();
        }
        [Test()]
        public void testPlayerStartsWithCorrectNumberOfCards()
        {
            Player p1 = new HumanPlayer();
            Assert.Fail();
        }
        [Test()]
        public void testPlayerStartsWithFiveCardHand()
        {
            Player p1 = new HumanPlayer();
            Assert.Fail();
        }
        [Test()]
        public void testPlayerStartsWithOnlyEstatesAndCopper()
        {
            Player p1 = new HumanPlayer();
            Assert.Fail();
        }
    }
}
