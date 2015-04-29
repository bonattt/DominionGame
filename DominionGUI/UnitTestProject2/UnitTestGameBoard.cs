using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestGameBoard
    {
        [TestMethod]
        public void TestTurnOrderDoesNotChange()
        {
            Assert.Fail("test not implemented");
        }
        [TestMethod]
        public void TestAddPlayerAddsAPlayer()
        {
            GameBoard board = new GameBoard(null);
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            Assert.AreSame(p1, board.NextPlayer());
        }
        [TestMethod]
        public void TestAddPlayerReturnsTrueWhenPlayerAdded()
        {
            GameBoard board = new GameBoard(null);
            Player p1 = new HumanPlayer(1);
            Assert.IsTrue(board.AddPlayer(p1));
        }
        [TestMethod]
        public void TestAddPlayerReturnsFalseWhenPlayerAlreadyInQueue()
        {
            GameBoard board = new GameBoard(null);
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            Assert.IsFalse(board.AddPlayer(p1));
        }
    }
}
