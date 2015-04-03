using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DominionGUI
{
    [TestFixture()]
    public class TestAddRandomCards
    {
        [Test()]
        public void TestIfCorrectNumberOfCardsAreAddedToGameBoard()
        {
            SelectNumPlayers s = new SelectNumPlayers();
            for (int i = 0; i < 100; i++)
            {
                s.addRandomCards();
                Assert.AreEqual(10, s.board.cards.Count);
            }
        }
    }
}
