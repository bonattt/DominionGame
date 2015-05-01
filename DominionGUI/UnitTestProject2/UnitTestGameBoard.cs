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
            GameBoard fakeBoard = mocks.DynamicMock<GameBoard>();
            Player p1 = mocks.DynamicMock<Player>();
            Player p2 = mocks.DynamicMock<Player>();
            Dictionary<Card, int> cards = GetTestCards();
            
            using (mocks.Ordered())
            {
                fakeBoard.PlayGame();
                for (int i = 0; i < 10; i++)
                {
                    p1.TakeTurn();
                    p2.TakeTurn();
                }
            }
            Expect.Call(fakeBoard.AddPlayer(p1)).CallOriginalMethod();
            Expect.Call(fakeBoard.AddPlayer(p2)).CallOriginalMethod();
            Expect.Call((()=>fakeBoard.PlayGame())).CallOriginalMethod();
            Expect.Call(fakeBoard.GameIsOver()).Repeat.Times(20).Return(false);
            Expect.Call(fakeBoard.GameIsOver()).Return(true);
            mocks.ReplayAll();
            fakeBoard.PlayGame();
            mocks.VerifyAll();
        }
        [TestMethod]
        public void TestGameEndsTrueWhenProvincesRunOut()
        {
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            cards[new Province()] = 0;
            Assert.IsTrue(board.GameIsOver());
        }
        [TestMethod]
        public void TestGameEndsTrueWhenThreePilesRunOut()
        {
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            cards[new Cellar()] = 0;
            cards[new Moat()] = 0;
            cards[new Woodcutter()] = 0;
            Assert.IsTrue(board.GameIsOver());
        }
        [TestMethod]
        public void TestEndsFalseIfOnlyTwoStacksEmpty()
        {
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            cards[new Cellar()] = 0;
            cards[new Estate()] = 0;
            Assert.IsFalse(board.GameIsOver());
        }

        private static Dictionary<Card, int> GetTestCards()
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
