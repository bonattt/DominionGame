using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;
using DominionCards.KingdomCards;
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
            Player p1 = mocks.DynamicMock<Player>();
            Player p2 = mocks.DynamicMock<Player>();
            Dictionary<Card, int> cards = GetTestDeck();

            using (mocks.Ordered())
            {
                for (int i = 0; i < 10; i++)
                {
                    p1.TakeTurn();
                    p2.TakeTurn();
                }
            }
            mocks.ReplayAll();
            GameBoard board = new GameBoard(cards);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            Console.WriteLine("about to PlayGame");
            board.PlayGame();
            mocks.VerifyAll();
        }

        private static Dictionary<Card, int> GetTestDeck()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards[new Cellar()] = 10;
            cards[new Moat()] = 10;
            cards[new Woodcutter()] = 10;
            cards[new Village()] = 10;
            cards[new Militia()] = 10;
            cards[new Mine()] = 10;
            cards[new Remodel()] = 10;
            cards[new Feast()] = 10;
            cards[new Workshop()] = 10;
            cards[new Market()] = 10;
            return cards;
        }
    }
}
