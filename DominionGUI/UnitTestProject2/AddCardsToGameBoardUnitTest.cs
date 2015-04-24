using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DominionCards;
using DominionCards.KingdomCards;

namespace UnitTestProject2
{
    [TestClass]
    public class AddCardsToGameBoardUnitTest
    {
        [TestMethod]
        public void testActionCardAddedToBoard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            Queue<Player> turns = new Queue<Player>();
            GameBoard board = new GameBoard(cards, turns);
            Card newCard = new Village();
            board.addCard(newCard);

            Assert.AreEqual(board.getCardsLeft(newCard), 10);
        }
        [TestMethod]
        public void testVictoryCardAddedToBoard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            Queue<Player> turns = new Queue<Player>();
            GameBoard board = new GameBoard(cards, turns);
            Card newCard = new Estate();
            board.addCard(newCard);

            Assert.AreEqual(board.getCardsLeft(newCard), 10);
        }
        [TestMethod]
        public void testTreasureCardAddedToBoard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            Queue<Player> turns = new Queue<Player>();
            GameBoard board = new GameBoard(cards, turns);
            Card newCard = new Copper();
            board.addCard(newCard);

            Assert.AreEqual(board.getCardsLeft(newCard), 10);
        }
    }
}
