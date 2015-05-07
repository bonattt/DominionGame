using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;
using DominionCards.KingdomCards;
using System.Collections.Generic;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestGameBoard
    {
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
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard fakeBoard = mocks.DynamicMock<GameBoard>(cards);

            Player p1 = mocks.DynamicMock<HumanPlayer>(1);
            Player p2 = mocks.DynamicMock<HumanPlayer>(2);
            
            using (mocks.Ordered())
            {
                fakeBoard.PlayGame();
                for (int i = 0; i < 10; i++)
                {
                    Expect.Call(()=>p1.TakeTurn(fakeBoard)).CallOriginalMethod(OriginalCallOptions.CreateExpectation);
                    Expect.Call(()=>p2.TakeTurn(fakeBoard)).CallOriginalMethod(OriginalCallOptions.CreateExpectation);
                    //p1.TakeTurn(fakeBoard);
                    //p2.TakeTurn(fakeBoard);
                }
            }
            Expect.Call(fakeBoard.AddPlayer(p1)).CallOriginalMethod(OriginalCallOptions.NoExpectation);
            Expect.Call(fakeBoard.AddPlayer(p2)).CallOriginalMethod(OriginalCallOptions.NoExpectation);
            Expect.Call((()=>fakeBoard.PlayGame())).CallOriginalMethod(OriginalCallOptions.NoExpectation);
            Expect.Call(fakeBoard.NextPlayer()).CallOriginalMethod(OriginalCallOptions.CreateExpectation);
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
        public void TestGameEndsFalseIfOnlyTwoStacksEmpty()
        {
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            cards[new Cellar()] = 0;
            cards[new Estate()] = 0;
            Assert.IsFalse(board.GameIsOver());
        }
        [TestMethod]
        public void IntegrationTestPlayGameAndGameIsOverUsingCustomPlayerMock()
        {
            MockRepository mocks = new MockRepository();
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            Player p1 = new SpecialPlayerMock();
            Player p2 = new SpecialPlayerMock();
            Player p3 = new SpecialPlayerMock();

            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            board.PlayGame();

            Assert.AreEqual(4, ((SpecialPlayerMock)p1).numbTimesCalled);
            Assert.AreEqual(3, ((SpecialPlayerMock)p2).numbTimesCalled);
            Assert.AreEqual(3, ((SpecialPlayerMock)p3).numbTimesCalled);
        }

        [TestMethod]
        public void IntegrationTestPlayCountVPWhenGameIsOverUsingPlayerMock()
        {
            MockRepository mocks = new MockRepository();
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            Player p1 = new SpecialPlayerMock();
            Player p2 = new SpecialPlayerMock();
            Player p3 = new SpecialPlayerMock();

            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            Assert.AreEqual(p1, board.PlayGame());

        }

        [TestMethod]
        public void IntegrationTestPlayCountVPWhenGameIsOverUsingPlayerMockWithTie()
        {
            MockRepository mocks = new MockRepository();
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            Player p1 = new SpecialPlayerMock();
            Player p2 = new SpecialPlayerMock();

            board.AddPlayer(p1);
            board.AddPlayer(p2);
            p2.getDiscard().Add(new Gold());
            Assert.AreEqual(p2, board.PlayGame());

        }
        [TestMethod]
        public void IntegrationTestTieIsThrownOnTrueTie()
        {
            MockRepository mocks = new MockRepository();
            Dictionary<Card, int> cards = GetTestCards();
            GameBoard board = new GameBoard(cards);
            Player p1 = new SpecialPlayerMock();
            Player p2 = new SpecialPlayerMock();

            board.AddPlayer(p1);
            board.AddPlayer(p2);
            try
            {
                board.PlayGame();
            }
            catch (TieException e)
            {
                Assert.AreEqual(2, e.getArraySize());
                return;
            }
            Assert.Fail("expected an exception");

        }
        public class SpecialPlayerMock : HumanPlayer
        {
            public int numbTimesCalled;
            public SpecialPlayerMock() : base()
            {
                numbTimesCalled = 0;
            }
            public override void TakeTurn(GameBoard board)
            {
                numbTimesCalled++;
                board.GetCards()[new Province()] -= 1;
                getDiscard().Add(new Province());
            }
        }
    }
}
