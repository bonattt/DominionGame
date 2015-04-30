using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;
using System.Collections.Generic;
using Rhino.Mocks;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestGameBoard
    {
        [TestMethod]
        public void TestTurnOrderDoesNotChange()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);

            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            Player p2 = new HumanPlayer(1);
            board.AddPlayer(p2);
            Player p3 = new HumanPlayer(1);
            board.AddPlayer(p3);
            Player p4 = new HumanPlayer(1);
            board.AddPlayer(p4);

            Assert.AreSame(p1, board.NextPlayer());
            Assert.AreSame(p2, board.NextPlayer());
            Assert.AreSame(p3, board.NextPlayer());
            Assert.AreSame(p4, board.NextPlayer());
        }
        [TestMethod]
        public void TestAddPlayerAddsAPlayer()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            Assert.AreSame(p1, board.NextPlayer());
        }
        [TestMethod]
        public void TestAddPlayerReturnsTrueWhenPlayerAdded()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            Assert.IsTrue(board.AddPlayer(p1));
        }
        [TestMethod]
        public void TestAddPlayerReturnsFalseWhenPlayerAlreadyInQueue()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            Assert.IsFalse(board.AddPlayer(p1));
        }
        [TestMethod]
        public void TestTurnOrderUsingMocks()
        {
            MockRepository mocks = new MockRepository();
            Player fakePlayer1 = mocks.StrictMock<Player>();

        }
    }
}
