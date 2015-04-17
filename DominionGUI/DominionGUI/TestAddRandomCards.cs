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
            new SelectNumPlayers();
            for (int i = 0; i < 100; i++)
            {
                SelectNumPlayers.INSTANCE.addRandomCards();
                Assert.AreEqual(10, SelectNumPlayers.INSTANCE.board.cards.Count);
            }
        }
    }
}
