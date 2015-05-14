using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using DominionCards;
using DominionCards.KingdomCards;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestChapel
    {
        private DominionCards.Player p1;
        private DominionCards.Player p2;
        private DominionCards.Player p3;
        private GameBoard board;
        private Card card;
        [TestInitialize]
        public void SetUp()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            board = new GameBoard(dict);
            p1 = new HumanPlayer(1);
            p1.setHand(new ArrayList());
            p2 = new HumanPlayer(2);
            p1.setHand(new ArrayList());
            p3 = new HumanPlayer(3);
            p1.setHand(new ArrayList());
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            card = new Chapel();
            p1.addCardToHand(card);
        }
        [TestMethod]
        public void PlayAChapel()
        {
            p1.playCard(card);
        }
    }
}
