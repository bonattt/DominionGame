using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominionCards;
using System.Collections.Generic;
using DominionCards.KingdomCards;
using System.Collections;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestAIplayer
    {
        private GameBoard board;
        private AIplayer p1;

        private GameBoard GetGameBoard()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            cards[new Province()] = 12;     // 8
            cards[new Gold()] = 30;         // 6
            cards[new Market()] = 10;       // 5
            cards[new Mine()] = 10;         // 5
            cards[new Duchy()] = 12;        // 5
            cards[new Remodel()] = 10;      // 4
            cards[new Feast()] = 10;        // 4
            cards[new Militia()] = 10;      // 4
            cards[new Workshop()] = 10;     // 3
            cards[new Silver()] = 40;       // 3
            cards[new Woodcutter()] = 10;   // 3
            cards[new Village()] = 10;      // 3
            cards[new Estate()] = 12;       // 2
            cards[new Cellar()] = 10;       // 2
            cards[new Moat()] = 10;         // 2
            cards[new Copper()] = 60;       // 0
            cards[new Curse()] = 30;        // 0
            return new GameBoard(cards);
        }

        private List<Card> GetCardList()
        {
            List<Card> list = new List<Card>();
            list.Add(new Province());   // 8
            list.Add(new Gold());       // 6
            list.Add(new Market());
            list.Add(new Mine());
            list.Add(new Duchy());      // 5
            list.Add(new Remodel());
            list.Add(new Smithy());
            list.Add(new Militia());
            list.Add(new Village());
            list.Add(new Woodcutter());
            list.Add(new Workshop());
            list.Add(new Silver());     // 3
            list.Add(new Cellar());
            list.Add(new Moat());
            list.Add(new Estate());     // 2
            list.Add(new Curse());
            list.Add(new Copper());     // 0
            return list;
        }
        private bool DuplicateListInDescendingOrder(List<Card> list)
        {
            int previousPrice = list[0].getPrice();
            Console.WriteLine(list[0] + ": " + list[0].getPrice());
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].getPrice() > previousPrice)
                {
                    return false;
                }
                previousPrice = list[i].getPrice();
                Console.WriteLine(list[i] + ": " + list[i].getPrice());
            }
            return true;
        }
        [TestInitialize]
        public void SetUp()
        {
            board = GetGameBoard();
            p1 = new AIplayer(1);
        }


        [TestMethod]
        public void TestCardSortWithNoDuplicates()
        {
            List<Card> expectedList = new List<Card>();
            expectedList.Add(new Province());   // 8
            expectedList.Add(new Gold());       // 6
            expectedList.Add(new Duchy());      // 5
            expectedList.Add(new Smithy());     // 4
            expectedList.Add(new Silver());     // 3
            expectedList.Add(new Estate());     // 2
            expectedList.Add(new Copper());     // 0

            List<Card> unsortedList = new List<Card>();
            unsortedList.Add(new Estate());     // 2
            unsortedList.Add(new Gold());       // 6
            unsortedList.Add(new Duchy());      // 5
            unsortedList.Add(new Province());   // 8
            unsortedList.Add(new Smithy());     // 4
            unsortedList.Add(new Copper());     // 0
            unsortedList.Add(new Silver());     // 3

            List<Card> sorted = AIplayer.SortCards(unsortedList, 4, 2);
            CollectionAssert.AreEqual(expectedList, sorted);
        }
        [TestMethod]
        public void TestCardsSortDuplicate()
        {
            List<Card> unsorted = new List<Card>();
            unsorted.Add(new Mine());       // 5
            unsorted.Add(new Silver());     // 3
            unsorted.Add(new Copper());     // 0
            unsorted.Add(new Province());   // 8
            unsorted.Add(new Duchy());      // 5
            unsorted.Add(new Estate());     // 2
            unsorted.Add(new Curse());      // 0
            unsorted.Add(new Cellar());     // 2
            unsorted.Add(new Moat());       // 2
            unsorted.Add(new Village());    // 3
            unsorted.Add(new Smithy());     // 4
            unsorted.Add(new Gold());       // 6
            unsorted.Add(new Woodcutter()); // 3
            unsorted.Add(new Militia());    // 4
            unsorted.Add(new Workshop());   // 3
            unsorted.Add(new Remodel());    // 4
            unsorted.Add(new Market());     // 5
            List<Card> sorted = AIplayer.SortCards(unsorted, 4, 2);
            Assert.IsTrue(DuplicateListInDescendingOrder(sorted));
        }
        [TestMethod]
        public void TestGetPriceRangeOfTen()
        {
            List<Card> list = p1.GetBestPriceRange(8);
            Assert.IsTrue(list.Contains(new Province()));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfNine()
        {
            List<Card> list = p1.GetBestPriceRange(8);
            Assert.IsTrue(list.Contains(new Province()));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfEight()
        {
            List<Card> list = p1.GetBestPriceRange(8);
            Assert.IsTrue(list.Contains(new Province()));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfSeven()
        {
            List<Card> list = p1.GetBestPriceRange(7);
            Assert.IsTrue(list.Contains(new Gold()));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfSix()
        {
            List<Card> list = p1.GetBestPriceRange(6);
            Assert.IsTrue(list.Contains(new Gold()));
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfFive()
        {
            List<Card> list = p1.GetBestPriceRange(5);
            Assert.IsTrue(list.Contains(new Duchy()));
            Assert.IsTrue(list.Contains(new Market()));
            Assert.IsTrue(list.Contains(new Mine()));
            Assert.AreEqual(3, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfFour()
        {
            List<Card> list = p1.GetBestPriceRange(4);
            Assert.IsTrue(list.Contains(new Feast()));
            Assert.IsTrue(list.Contains(new Remodel()));
            Assert.IsTrue(list.Contains(new Militia()));
            Assert.AreEqual(3, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfThree()
        {
            List<Card> list = p1.GetBestPriceRange(3);
            Assert.IsTrue(list.Contains(new Village()));
            Assert.IsTrue(list.Contains(new Woodcutter()));
            Assert.IsTrue(list.Contains(new Workshop()));
            Assert.IsTrue(list.Contains(new Silver()));
            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void TestGetPriceRangeOfTwo()
        {
            List<Card> list = p1.GetBestPriceRange(2);
            Assert.IsTrue(list.Contains(new Estate()));
            Assert.IsTrue(list.Contains(new Moat()));
            Assert.IsTrue(list.Contains(new Cellar()));
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestGetPriceRangeOfOne()
        {
            List<Card> list = p1.GetBestPriceRange(1);
            Assert.IsTrue(list.Contains(new Copper()));
            // Assert.IsTrue(list.Contains(new Curse())); -- curse not included b/c the AI never buys a curse.
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestGetPriceRangeOfZero()
        {
            List<Card> list = p1.GetBestPriceRange(0);
            Assert.IsTrue(list.Contains(new Copper()));
            //Assert.IsTrue(list.Contains(new Curse())); -- curse not included b/c the AI never buys a curse.
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestSelectByActionsSelectsWithMostActions()
        {
            List<ActionCard> expected = new List<ActionCard>();
            expected.Add(new Village());
            expected.Add(new Village());
            expected.Add(new Laboratory());
            expected.Add(new Laboratory());
            expected.Add(new Woodcutter());
            List<ActionCard> list = new List<ActionCard>();
            list.Add(new Woodcutter());
            list.Add(new Laboratory());
            list.Add(new Village());
            list.Add(new Laboratory());
            list.Add(new Village());
            int i = 0;
            while (list.Count > 0)
            {
                ActionCard card = p1.selectByActions(list);
                Assert.AreEqual(expected[i], card);
                list.Remove(card);
                i++;
            }
        }

        [TestMethod]
        public void TestSelectByActionsBreaksTiesByMoneyWithOneActionLeft()
        {

            List<ActionCard> expected = new List<ActionCard>();
            expected.Add(new Festival());   // 2 act, 2 money
            expected.Add(new Village());    // 2 act, 1 card
            expected.Add(new Market());     // 1 act, 1 money
            expected.Add(new Laboratory()); // 1 act, 2 card
            expected.Add(new Woodcutter()); // 
            expected.Add(new Moat());       // 

            List<ActionCard> list = new List<ActionCard>();
            list.Add(new Woodcutter()); // 
            list.Add(new Village());    // 2 act, 1 card
            list.Add(new Laboratory()); // 1 act, 2 card
            list.Add(new Festival());   // 2 act, 2 money
            list.Add(new Moat());       //
            list.Add(new Market());     // 1 act, 1 money
            
            int i = 0;
            while (list.Count > 0)
            {
                ActionCard card = p1.selectByActions(list);
                Assert.AreEqual(expected[i], card);
                list.Remove(card);
                i++;
            }
        }
        [TestMethod]
        public void TestSelectByActionsBreaksTiesByCardsWithTwoActionLeft()
        {
            p1.actions = 2;
            List<ActionCard> expected = new List<ActionCard>();
            expected.Add(new Village());    // 2 act, 1 card
            expected.Add(new Festival());   // 2 act, 2 money
            expected.Add(new Laboratory()); // 1 act, 2 card
            expected.Add(new Market());     // 1 act, 1 money
            expected.Add(new Moat());       // 
            expected.Add(new Woodcutter()); // 

            List<ActionCard> list = new List<ActionCard>();
            list.Add(new Woodcutter()); // 
            list.Add(new Village());    // 2 act, 1 card
            list.Add(new Laboratory()); // 1 act, 2 card
            list.Add(new Festival());   // 2 act, 2 money
            list.Add(new Moat());       //
            list.Add(new Market());     // 1 act, 1 money
            
            int i = 0;
            while (list.Count > 0)
            {
                ActionCard card = p1.selectByActions(list);
                Assert.AreEqual(expected[i], card);
                list.Remove(card);
                i++;
            }
        }

        [TestMethod]
        public void TestActionPhasePlaysOneCard()
        {
            ArrayList newHand = new ArrayList();
            newHand.Add(new Copper());
            newHand.Add(new Silver());
            newHand.Add(new Gold());
            newHand.Add(new Estate());
            newHand.Add(new Duchy());
            newHand.Add(new Village());
            newHand.Add(new Province());
            p1.setHand(newHand);
            int handCount = p1.getHand().Count;
            int discardCount = p1.getDiscard().Count;
            int deckCount = p1.getDeck().Count;
            int actionCount = p1.actionsLeft();
            p1.actionPhase();
            Assert.AreEqual(handCount, p1.getHand().Count);
            Assert.AreEqual(discardCount + 1, p1.getDiscard().Count);
            Assert.AreEqual(actionCount + 1, p1.actionsLeft());
            Assert.AreEqual(deckCount - 1, p1.getDeck().Count);
        }
        [TestMethod]
        public void TestActionPhasePlaysTwoCardsInOrder()
        {
            ArrayList newHand = new ArrayList();
            newHand.Add(new Smithy());
            newHand.Add(new Village());
            p1.setHand(newHand);
            int handCount = p1.getHand().Count;
            int discardCount = p1.getDiscard().Count;
            int deckCount = p1.getDeck().Count;
            int actionCount = p1.actionsLeft();
            p1.actionPhase();
            Assert.AreEqual(handCount, p1.getHand().Count);
            Assert.AreEqual(discardCount + 1, p1.getDiscard().Count);
            Assert.AreEqual(actionCount + 1, p1.actionsLeft());
            Assert.AreEqual(deckCount - 1, p1.getDeck().Count);
            p1.actionPhase();
            Assert.AreEqual(handCount + 2, p1.getHand().Count);
            Assert.AreEqual(discardCount + 2, p1.getDiscard().Count);
            Assert.AreEqual(actionCount, p1.actionsLeft());
            Assert.AreEqual(deckCount - 4, p1.getDeck().Count);
        }
        

    }
}
