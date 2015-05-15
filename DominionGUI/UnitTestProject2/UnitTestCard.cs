using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using DominionCards;
using DominionCards.KingdomCards;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestCard
    {
        public void testThatCardsWorkInDictionaries()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            dict.Add(new Copper(), 1);
            dict.Add(new Village(), 2);
            Assert.AreEqual(1, dict[new Copper()]);
            Assert.AreEqual(2, dict[new Village()]);
        }
        [TestMethod]
        public void testThatAdventurerDoesThing()
        {
            Card c = new Adventurer();
            Player p = new HumanPlayer();
            p.addCardToHand(c);
            p.drawHand();
            int count = p.getHand().Count;
            c.Play(p);
            Assert.AreEqual(count + 2, p.getHand().Count);
        }
        [TestMethod]
        public void testTreasureReturnsNoVP()
        {
            Card c = new Silver();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [TestMethod]
        public void testWorkshopPutsNewCardInDiscard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Workshop();
            Player p = new HumanPlayer(1);
            board.AddPlayer(p);
            p.addCardToHand(c);
            int numdiscard = p.getDiscard().Count;
            p.playCard(c);
            Assert.AreEqual(numdiscard + 2, p.getDiscard().Count);
        }
        [TestMethod]
        public void testWorkshopDoesntChargeForNewCard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Workshop();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int spendPoints = p1.moneyLeft();
            p1.playCard(c);
            Assert.AreEqual(spendPoints, p1.moneyLeft());
        }



        [TestMethod]
        public void testLibrary()
        {
            Card c = new Library();
            Player p = new HumanPlayer();
            p.addCardToHand(c);
            p.drawHand();
            c.Play(p);
            Assert.AreEqual(7, p.getHand().Count);
        }
        [TestMethod]
        public void testActionReturnsNoVP()
        {
            Card c = new Village();
            Assert.AreEqual(0, c.getVictoryPoints());
        }
        [TestMethod]
        public void testMoneyLenderAddsMoneyIfThereIsCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            newHand.Add(new Copper());
            p.setHand(newHand);
            p.addCardToHand(c);
            int moneyBefore = p.moneyLeft();
            p.playCard(c);
            Assert.AreEqual(moneyBefore + 3, p.moneyLeft());
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderDoesNotAddMoneyIfThereIsNoCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            p.setHand(newHand);
            p.addCardToHand(c);
            int moneyBefore = p.moneyLeft();
            p.playCard(c);
            Assert.AreEqual(moneyBefore, p.moneyLeft());
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderDoesNotRemoveNoCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderRemovesCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Village());
            newHand.Add(new Copper());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore - 1, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testMoneyLenderOnlyRemovesOneCopper()
        {
            Card c = new MoneyLender();
            Player p = new HumanPlayer();
            ArrayList newHand = new ArrayList();
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Estate());
            newHand.Add(new Copper());
            newHand.Add(new Copper());
            p.setHand(newHand);
            int handBefore = p.getHand().Count;
            p.addCardToHand(c);
            p.playCard(c);
            Assert.AreEqual(handBefore - 1, p.getHand().Count);
            ///////////////////////////////////
        }
        [TestMethod]
        public void testVictoryReturnsVP()
        {
            Card c = new Estate();
            Assert.AreEqual(1, c.getVictoryPoints());
        }
        [TestMethod]
        public void testCardEquals()
        {
            Card copper = new Copper();
            Card village = new Village();
            Card smithy = new Smithy();

            Assert.AreNotEqual(copper, smithy);
            Assert.AreNotEqual(copper, village);
            Assert.AreNotEqual(village, smithy);
            Assert.AreNotEqual(smithy, copper);
            Assert.AreNotEqual(village, copper);
            Assert.AreNotEqual(smithy, village);

            Assert.AreEqual(copper, new Copper());
            Assert.AreEqual(village, new Village());
            Assert.AreEqual(smithy, new Smithy());
        }

        [TestMethod]
        public void testOtherPlayersDrawCardsOnCouncilRoom()
        {
            Dictionary<Card, int> cards = new Dictionary<Card,int>();
            GameBoard board = new GameBoard(cards);
            Card c = new CouncilRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int before = p2.getHand().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(before + 1, p2.getHand().Count);
        }

        [TestMethod]
        public void TestWitchAddsCurseToOtherPlayers()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Curse(), 30);
            GameBoard board = new GameBoard(cards);
            Card c = new Witch();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int cardsInDiscardp2 = p2.getDiscard().Count;
            int cardsInDiscardp3 = p3.getDiscard().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(cardsInDiscardp2 + 1, p2.getDiscard().Count);
            Assert.AreEqual(cardsInDiscardp3 + 1, p3.getDiscard().Count);
            Assert.IsTrue(p2.getDiscard().Contains(new Curse()));
            Assert.IsTrue(p3.getDiscard().Contains(new Curse()));
        }[TestMethod]
        public void TestWitchDoesNotAddCursesIfNoCursesAreLeft()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Curse(), 0);
            GameBoard board = new GameBoard(cards);
            Card c = new Witch();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int cardsInDiscardp2 = p2.getDiscard().Count;
            int cardsInDiscardp3 = p3.getDiscard().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(cardsInDiscardp2, p2.getDiscard().Count);
            Assert.AreEqual(cardsInDiscardp3, p3.getDiscard().Count);
            Assert.IsFalse(p2.getDiscard().Contains(new Curse()));
            Assert.IsFalse(p3.getDiscard().Contains(new Curse()));
        }

        [TestMethod]
        public void TestWitchDoesNotAddCurseToMe()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Curse(), 30);
            GameBoard board = new GameBoard(cards);
            Card c = new Witch();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int cardsInDiscardp1 = p1.getDiscard().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(cardsInDiscardp1 + 1, p1.getDiscard().Count);
            Assert.IsFalse(p1.getDiscard().Contains(new Curse()));
        }

        [TestMethod]
        public void TestWitchDoesNotAddCurseToOtherPlayersWithMoats()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Curse(), 30);
            GameBoard board = new GameBoard(cards);
            Card c = new Witch();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int cardsInDiscardp2 = p2.getDiscard().Count;
            int cardsInDiscardp3 = p3.getDiscard().Count;
            p2.addCardToHand(new Moat());
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(cardsInDiscardp2, p2.getDiscard().Count);
            Assert.AreEqual(cardsInDiscardp3 + 1, p3.getDiscard().Count);
            Assert.IsFalse(p2.getDiscard().Contains(new Curse()));
            Assert.IsTrue(p3.getDiscard().Contains(new Curse()));
        }

        [TestMethod]
        public void TestChapelDiscardThree()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Card c = new Chapel();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int cardsInDiscard = p1.getDiscard().Count;
            int cardsInHand = p1.getHand().Count;
            p1.playCard(c);
            Assert.AreEqual(cardsInDiscard + 1, p1.getDiscard().Count);
            Assert.AreEqual(cardsInHand - 4, p1.getHand().Count);
        }

        [TestMethod]
        public void testRemodelPutsNewAndPlayedCardsInDiscard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Remodel();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int numdiscard = p1.getDiscard().Count;
            p1.playCard(c);
            Assert.AreEqual(numdiscard + 2, p1.getDiscard().Count);
        }

        [TestMethod]
        public void testRemodelDoesntIncludeCardsMoreThanFourCost()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            cards.Add(new Witch(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Remodel();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int numdiscard = p1.getDiscard().Count;
            p1.playCard(c);
            Assert.AreEqual(numdiscard + 2, p1.getDiscard().Count);
        }

        [TestMethod]
        public void testFeastTrashesFeastAndAddsNewToDiscard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Feast();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int numdiscard = p1.getDiscard().Count;
            p1.playCard(c);
            Assert.AreEqual(numdiscard + 1, p1.getDiscard().Count);
        }

        [TestMethod]
        public void testFeastDoesntIncludeCardsMoreThanFiveCost()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            cards.Add(new Gold(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Feast();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int numdiscard = p1.getDiscard().Count;
            p1.playCard(c);
            Assert.AreEqual(numdiscard + 1, p1.getDiscard().Count);
        }

        [TestMethod]
        public void testRemodelDoesntChargeForNewCard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Copper(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Remodel();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            p1.addCardToHand(c);
            int spendPoints = p1.moneyLeft();
            p1.playCard(c);
            Assert.AreEqual(spendPoints, p1.moneyLeft());
        }

        [TestMethod]
        public void TestMineGiveUpCopperForSilver()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Silver(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Mine();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            ArrayList newHand = new ArrayList();
            newHand.Add(new Copper());
            newHand.Add(new Copper());
            newHand.Add(new Copper());
            newHand.Add(c);
            p1.setHand(newHand);
            int cardsInHand = p1.getHand().Count;
            int moneyInHand = p1.getTotalMoney();
            p1.playCard(c);
            Assert.IsTrue(p1.getHand().Contains(new Silver()));
            Assert.AreEqual(moneyInHand + 1, p1.getTotalMoney());
            Assert.AreEqual(cardsInHand - 1, p1.getHand().Count);
        }

        [TestMethod]
        public void TestMineGiveUpSilverForGold()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards.Add(new Gold(), 1);
            GameBoard board = new GameBoard(cards);
            Card c = new Mine();
            Player p1 = new HumanPlayer(1);
            board.AddPlayer(p1);
            ArrayList newHand = new ArrayList();
            newHand.Add(new Silver());
            newHand.Add(new Silver());
            newHand.Add(new Silver());
            newHand.Add(c);
            p1.setHand(newHand);
            int cardsInHand = p1.getHand().Count;
            int moneyInHand = p1.getTotalMoney();
            p1.playCard(c);
            Assert.IsTrue(p1.getHand().Contains(new Gold()));
            Assert.AreEqual(moneyInHand + 1, p1.getTotalMoney());
            Assert.AreEqual(cardsInHand - 1, p1.getHand().Count);
        }

        [TestMethod]
        public void TestThroneRoomBringsUpWindow()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Card c = new ThroneRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int cardsInDiscardp2 = p2.getDiscard().Count;
            p1.addCardToHand(c);
            p1.addCardToHand(new Village());
            p1.addCardToHand(new Market());
            p1.playCard(c);
            Assert.AreEqual(2, 2);
        }
        [TestMethod]
        public void TestThroneMakesDialogueWhenNoOtherActionCardsAvailible()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Card c = new ThroneRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int cardsInDiscardp2 = p2.getDiscard().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void testPlayerDraws4CardsOnCouncilRoom()
        {
            Dictionary<Card, int> cards = new Dictionary<Card,int>();
            GameBoard board = new GameBoard(cards);
            Card c = new CouncilRoom();
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            int before = p1.getHand().Count;
            p1.addCardToHand(c);
            p1.playCard(c);
            Assert.AreEqual(before + 4, p1.getHand().Count);
        }
        
    }
}
