using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using RandomGenerateCards;
using DominionCards;
using DominionCards.KingdomCards;
//using Rhino.Mocks;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void TestIsActionPhaseWheneverPlayerHasTreasure()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(dict);
            HumanPlayer p1 = new HumanPlayer(1);
            p1.actions = 0;
            ArrayList cardList = new ArrayList();
            cardList.Add(new Copper());
            cardList.Add(new Estate());
            p1.setHand(cardList);

            HumanPlayerTurn turn = new HumanPlayerTurn(p1);
            Assert.IsTrue(turn.IsActionPhase());
        }
        [TestMethod]
        public void TestIsActionPhaseIsFalseWithoutActionCard()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(dict);
            HumanPlayer p1 = new HumanPlayer(1);
            ArrayList hand = new ArrayList();
            hand.Add(new Estate());
            p1.setHand(hand);

            HumanPlayerTurn turn = new HumanPlayerTurn(p1);
            Assert.IsFalse(turn.IsActionPhase());
        }
        [TestMethod]
        public void TestIsActionPhaseIsFalseWithoutAction()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(dict);
            HumanPlayer p1 = new HumanPlayer(1);
            ArrayList hand = new ArrayList();
            hand.Add(new Estate());
            hand.Add(new Witch());
            p1.actions = 0;
            p1.setHand(hand);
            HumanPlayerTurn turn = new HumanPlayerTurn(p1);
            Assert.IsFalse(turn.IsActionPhase());
        }
        [TestMethod]
        public void TestIsActionPhaseIsTrueWithActionsAndCards()
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(dict);
            HumanPlayer p1 = new HumanPlayer(1);
            ArrayList hand = new ArrayList();
            hand.Add(new Estate());
            hand.Add(new Witch());
            p1.setHand(hand);

            HumanPlayerTurn turn = new HumanPlayerTurn(p1);
            Assert.IsTrue(turn.IsActionPhase());
        }

        [TestMethod]
        public void TestFiveCardsDrawnEvenIfDeckEmpty()
        {
            Player p = new HumanPlayer();
            Stack<Card> deck = p.getDeck();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 0)
            {
                newDiscard.Add(deck.Pop());
            }
            p.setDiscard(newDiscard);
            p.drawHand();
            Assert.AreEqual(5, p.getHand().Count);
        }
        [TestMethod]
        public void DeckShufflesWhenHandDrawnFromTooSmallDeck_FiveCardsDrawn()
        {
            Player p = new HumanPlayer();
            Stack<Card> deck = p.getDeck();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 2)
            {
                newDiscard.Add(deck.Pop());
            }
            p.setDiscard(newDiscard);
            p.drawHand();
            Assert.AreEqual(5, p.getHand().Count);
        }
        [TestMethod]
        public void DeckShufflesWhenHandDrawnFromTooSmallDeck_DiscardEmpty()
        {
            Player p = new HumanPlayer();
            Stack<Card> deck = p.getDeck();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 2)
            {
                newDiscard.Add(deck.Pop());
            }
            p.setDiscard(newDiscard);
            p.drawHand();
            Assert.AreEqual(0, p.getDiscard().Count);
        }
        [TestMethod]
        public void DeckShufflesWhenHandDrawnFromTooSmallDeck_DeckHasCorrectNumbCards()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            ArrayList hand = p1.getHand();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 2)
            {
                newDiscard.Add(deck.Pop());
            }
            for (int i = 0; i < hand.Count; i++){
                newDiscard.Add(hand[i]);
            }
            p1.setHand(new ArrayList());
            p1.setDiscard(newDiscard);
            int discardCount = newDiscard.Count;
            int deckCount = p1.getDeck().Count;
            int expectedShuffledDeckSize = discardCount - 5 + deckCount;
            p1.drawHand();
            Assert.AreEqual(expectedShuffledDeckSize, p1.getDeck().Count);
        }
        [TestMethod]
        public void testDiscardGoesToDeckWhenCardIsDrawnAndDeckIsEmpty()
        {
            Player p = new HumanPlayer();
            Stack<Card> deck = p.getDeck();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 0)
            {
                newDiscard.Add(deck.Pop());
            }
            p.setDiscard(newDiscard);
            int discardSize = newDiscard.Count;
            p.GetNextCard();
            Assert.AreEqual(discardSize - 1, p.getDeck().Count);
        }
        [TestMethod]
        public void testDiscardGoesAwayWhenDeckIsShuffledDrawingCards()
        {
            Player p = new HumanPlayer();
            Stack<Card> deck = p.getDeck();
            ArrayList newDiscard = new ArrayList();
            while (deck.Count > 0)
            {
                newDiscard.Add(deck.Pop());
            }
            p.setDiscard(newDiscard);
            int discardSize = newDiscard.Count;
            p.GetNextCard();
            Assert.AreEqual(0, p.getDiscard().Count);
        }
        [TestMethod]
        public void testDrawHandDiscardsOldHand()
        {
            Player p1 = new HumanPlayer();
            p1.drawHand();
            ArrayList hand = p1.getHand();
            p1.drawHand();
            Assert.AreEqual(hand, p1.getHand());
        }
        [TestMethod]
        public void playingTreasureCardDoesntUseAnAction()
        {
            Player p1 = new HumanPlayer();
            int a = p1.actionsLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Copper());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(a, p1.actionsLeft());
        }
        [TestMethod]
        public void playingTreasureCardDoesntAddBuys()
        {
            Player p1 = new HumanPlayer();
            int b = p1.buysLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Gold());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(b, p1.actionsLeft());
        }
        [TestMethod]
        public void playingTreasureCardDoesntDrawCards()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = new ArrayList();
            hand.Add(new Gold());
            int cards = hand.Count;
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(cards - 1, p1.getHand().Count);
        }
        [TestMethod]
        public void testCountVictoryPointsCountsBasicVictoryCards(){
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            Assert.AreEqual(0, p1.countVictoryPoints());
            deck.Push(new Estate());
            Assert.AreEqual(1, p1.countVictoryPoints());
            deck.Push(new Duchy());
            Assert.AreEqual(4, p1.countVictoryPoints());
            deck.Push(new Province());
            Assert.AreEqual(10, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountVictoryPointsCountsGardens()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            for (int i = 0; i < 9; i++)
            {
                deck.Push(new Militia());
            }
            deck.Push(new Gardens());
            Assert.AreEqual(1, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountVictoryPointsCountsGardensRoundsDown()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            for (int i = 0; i < 8; i++)
            {
                deck.Push(new Militia());
            }
            deck.Push(new Gardens());
            Assert.AreEqual(0, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountVictoryPointsCountsGardensDoesntRoundUp()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            for (int i = 0; i < 11; i++)
            {
                deck.Push(new Militia());
            }
            deck.Push(new Gardens());
            Assert.AreEqual(1, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountVictoryPointsCountsGardensCanBeMoreThanOne()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            for (int i = 0; i < 22; i++)
            {
                deck.Push(new Militia());
            }
            deck.Push(new Gardens());
            Assert.AreEqual(2, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountVictoryPointsCountsGardensWithMultipleGardens()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setDeck(deck);
            p1.setHand(new ArrayList());
            for (int i = 0; i < 9; i++)
            {
                deck.Push(new Militia());
            }
            deck.Push(new Gardens());
            deck.Push(new Gardens());
            Assert.AreEqual(2, p1.countVictoryPoints());
        }

        [TestMethod]
        public void drawFiveCardsWhenDeckRunsOut()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            ArrayList discard = new ArrayList();
            p1.setDeck(deck);
            p1.setDiscard(discard);

            // add 3 Estate cards to the deck
            for (int i = 0; i < 3; i++)
            {
                deck.Push(new Estate());
            }
            // add 3 copper cards to the discard
            for (int i = 0; i < 3; i++)
            {
                discard.Add(new Copper());
            }
            p1.drawHand();

            ArrayList hand = p1.getHand();
            Assert.AreEqual(5, hand.Count);
        }
        [TestMethod]
        public void drawCardsStillOnDeckFirstWhenDeckRunsOut()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            ArrayList discard = new ArrayList();
            ArrayList hand = new ArrayList();

            deck.Push(new Witch());
            deck.Push(new Gold());
            
            for (int i = 0; i < 5; i++)
            {
                discard.Add(new Copper());
            }

            p1.setHand(hand);
            p1.setDeck(deck);
            p1.setDiscard(discard);

            p1.drawHand();

            hand = p1.getHand();
            Assert.AreEqual(new Gold(), hand[0]);
            Assert.AreEqual(new Witch(), hand[1]);
        }
        [TestMethod]
        public void testCountVictoryPointsWhenCardsInDiscard(){
            Player p1 = new HumanPlayer();
            p1.setHand(new ArrayList());
            Stack<Card> deck = new Stack<Card>();
            ArrayList discard = p1.getDiscard();
            p1.setDeck(deck);
            Assert.AreEqual(0, p1.countVictoryPoints());
            deck.Push(new Province());
            Assert.AreEqual(6, p1.countVictoryPoints());
            deck.Push(new Duchy());
            Assert.AreEqual(9, p1.countVictoryPoints());
            discard.Add(new Duchy());
            Assert.AreEqual(12, p1.countVictoryPoints());
        }
        [TestMethod]
        public void testCountVictoryPointsWhenCardsInHand(){
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            ArrayList hand = new ArrayList();
            p1.setDeck(deck);
            p1.setHand(hand);
            Assert.AreEqual(0, p1.countVictoryPoints());
            deck.Push(new Estate());
            Assert.AreEqual(1, p1.countVictoryPoints());
            deck.Push(new Province());
            Assert.AreEqual(7, p1.countVictoryPoints());
            hand.Add(new Province());
            Assert.AreEqual(13, p1.countVictoryPoints());
        }

        [TestMethod]
        public void testCountTotalMoneyinDeck()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setHand(new ArrayList());
            deck.Push(new Gold());
            p1.setDeck(deck);
            Assert.AreEqual(3, p1.getTotalMoney());
        }

        [TestMethod]
        public void testCountTotalMoneyWithCardsinDiscard()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = new Stack<Card>();
            p1.setHand(new ArrayList());
            ArrayList discard = p1.getDiscard();
            discard.Add(new Gold());
            p1.setDeck(deck);
            Assert.AreEqual(3, p1.getTotalMoney());
        }
        [TestMethod]
        public void playingTreasureCardAddsMoney()
        {
            Player p1 = new HumanPlayer();
            int m = p1.moneyLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Silver());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(m + 2, p1.moneyLeft());
        }
        [TestMethod]
        public void testDrawHandDrawsFiveCards()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();

            p1.drawHand();
            Assert.AreEqual(5, hand.Count);
        }
        [TestMethod]
        public void testDrawHandRemovesFiveCardsFromDeck()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int initialDeck = deck.Count;

            p1.drawHand();
            Assert.AreEqual(initialDeck - 5, deck.Count);
        }

        [TestMethod]
        public void testPlayerStartsWithCorrectNumberOfEstates()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            ArrayList hand = p1.getHand();
            int numbEstates = 0;
            while (deck.Count > 0)
            {
                if (deck.Pop().getID() == 3)
                {
                    numbEstates++;
                }
            }
            for (int i = 0; i < hand.Count; i++)
            {
                int id = ((Card)hand[i]).getID();
                if (id == 3)
                {
                    numbEstates++;
                }
            }
                Assert.AreEqual(3, numbEstates);
        }
        [TestMethod]
        public void testPlayerStartsWithCorrectNumberOfCopper()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int numbCopper = 0;
            while (deck.Count > 0)
            {
                if (deck.Pop().getID() == 0)
                {
                    numbCopper++;
                }
            }
            for (int i = 0; i < p1.getHand().Count; i++)
            {
                int id = ((Card) p1.getHand()[i]).getID();
                if (id == 0)
                {
                    numbCopper++;
                }
            }
                Assert.AreEqual(7, numbCopper);
        }
        [TestMethod]
        public void testPlayerStartsWithCorrectNumberOfCards()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            Assert.AreEqual(5, deck.Count);
            Assert.AreEqual(5, p1.getHand().Count);
        }
        [TestMethod]
        public void testPlayerStartsWithOnlyEstatesAndCopper()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();
            for (int i = 0; i < hand.Count; i++)
            {
                if (((Card)hand[i]).getID() != 0 && ((Card)hand[i]).getID() != 3)
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void testDrawCardMakesDeckSmaller()
        {
            Player p1 = new HumanPlayer();
            Stack<Card> deck = p1.getDeck();
            int initialDeckSize = deck.Count;
            p1.GetNextCard();
            Assert.AreEqual(initialDeckSize - 1, deck.Count);
        }
        [TestMethod]
        public void testDrawCardMakesHandBigger()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = p1.getHand();

            Card c = new Smithy();
            hand.Add(c);
            int initialDeckSize = hand.Count;
            p1.setHand(hand);
            p1.playCard(c);

            Assert.AreEqual(initialDeckSize + 2, hand.Count);
        }
        [TestMethod]
        public void playingActionCardReducesActionsByOne()
        {
            Player p1 = new HumanPlayer();
            int a = p1.actionsLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Smithy());
            p1.setHand(hand);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(a - 1, p1.actionsLeft());
        }
        [TestMethod]
        public void playingCardRemovesCardFromHand()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = new ArrayList();
            hand.Add(new Woodcutter());
            p1.setHand(hand);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(0, p1.getHand().Count);
        }
        [TestMethod]
        public void playingCardWithBuysAddsBuys()
        {
            Player p1 = new HumanPlayer();
            int b = p1.buysLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Woodcutter());
            p1.setHand(hand);
            p1.playCard((Card) hand[0]);
            Assert.AreEqual(b+1, p1.buysLeft());
        }
        [TestMethod]
        public void playingCardWithoutBuysDoesntAddBuys()
        {
            Player p1 = new HumanPlayer();
            int b = p1.buysLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Smithy());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(b, p1.buysLeft());
        }
        [TestMethod]
        public void playingCardWithActionsAddsActions()
        {
            Player p1 = new HumanPlayer();
            int a = p1.actionsLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Village());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(a+1, p1.actionsLeft());
        }
        [TestMethod]
        public void playingCardWithMoneyAddsMoney()
        {
            Player p1 = new HumanPlayer();
            int m = p1.moneyLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Festival());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(m+2, p1.moneyLeft());
        }
        [TestMethod]
        public void testShuffledDeckContainsSameCards()
        {
            Stack<Card> deck = new Stack<Card>();
            Dictionary<int, int> count;
            Dictionary<int, int> expct = new Dictionary<int, int>();

            deck.Push(new Copper());
            deck.Push(new Copper());
            deck.Push(new Copper());
            deck.Push(new Village());
            deck.Push(new Village());
            deck.Push(new Smithy());

            count = countCards(deck);
            expct.Add(new Copper().getID(), 3);
            expct.Add(new Village().getID(), 2);
            expct.Add(new Smithy().getID(), 1);

            Console.WriteLine(expct);
            Console.WriteLine(count);

            foreach (int id in count.Keys)
            {
                Assert.AreEqual(expct[id], count[id]);
            }
        }
        private static void CompareCounts(Dictionary<Card, int> expect, Dictionary<Card, int> cardCount)
// TODO MARKED FOR DEMOLITION
        {
            foreach (KeyValuePair<Card, int> entry in expect)
            {
                //Assert.AreEqual(entry.Value, cardCount[entry.Key]);
                Console.WriteLine("expected: " + entry.Key.getID() + ", " + entry.Value);
                if (cardCount.ContainsKey(entry.Key))
                {
                    Console.WriteLine("returned: " + entry.Key.getID() + ", " + cardCount[entry.Key]);
                }
            }
        }

        [TestMethod]
        public void testConvertStackToCardStack()
        {
            Stack objStack = new Stack();
            Stack<Card> dumpStack;
            Stack<Card> expct = new Stack<Card>();
            expct.Push(new Copper());
            expct.Push(new Copper());
            expct.Push(new Duchy());
            expct.Push(new Smithy());
            objStack.Push(new Smithy());
            objStack.Push(new Duchy());
            objStack.Push(new Copper());
            objStack.Push(new Copper());

            dumpStack = Player.ConvertStackToCardStack(objStack);

            while (expct.Count > 0)
            {
                Assert.AreEqual(expct.Pop().getID(), dumpStack.Pop().getID());
            }
            Assert.AreEqual(expct.Count, dumpStack.Count);
        }

        [TestMethod]
        public void playingCardWithoutMoneyDoesntAddMoney()
        {
            Player p1 = new HumanPlayer();
            int m = p1.moneyLeft();
            ArrayList hand = new ArrayList();
            hand.Add(new Laboratory());
            p1.setHand(hand);
            
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(m, p1.moneyLeft());
        }
        [TestMethod]
        public void playingCardThatDrawsCards()
        {
            Player p1 = new HumanPlayer();
            ArrayList hand = new ArrayList();
            hand.Add(new Laboratory());
            p1.setHand(hand);
            p1.playCard((Card)hand[0]);
            Assert.AreEqual(2, hand.Count);
        }

        [TestMethod]
        public void buyingAddsCardToDiscard()
        {
            Player p1 = new HumanPlayer();
            ArrayList discard = new ArrayList();
            p1.setDiscard(discard);
            Card laboratory = new Laboratory();
            int discardSize = discard.Count;
            p1.buyCard(laboratory);
            Assert.AreEqual(discardSize, p1.getDiscard().Count);
        }

        [TestMethod]
        public void testBuyLowersNumBuysWithEnoughMoney()
        {
            Player p1 = new HumanPlayer();
            int originalBuys = p1.buysLeft();
            Card purchase = new Laboratory();  //5
            ArrayList tempHand = new ArrayList();
            Card gold1 = new Gold();
            Card gold2 = new Gold();
            tempHand.Add(gold1);
            tempHand.Add(gold2);
            p1.setHand(tempHand);
            p1.playCard(gold1); //this makes it so that you have enough money to buy the card
            p1.playCard(gold2); //same
            p1.buyCard(purchase);
            int buysAfter = p1.buysLeft();
            Assert.AreEqual((originalBuys - 1), buysAfter);
        }

        [TestMethod]
        public void testBuyLowersNumBuysNotEnoughMoney()
        {
            Player p1 = new HumanPlayer();
            int originalBuys = p1.buysLeft();
            Card purchase = new Laboratory();  //5
            p1.buyCard(purchase);
            int buysAfter = p1.buysLeft();
            Assert.AreEqual(originalBuys, buysAfter);
        }

        [TestMethod]
        public void buyingExpensiveCardTakesMoneyFromPlayer()
        {
            Player p1 = new HumanPlayer();
            Card purchase = new Laboratory();  //5
            ArrayList tempHand = new ArrayList();
            Card gold1 = new Gold();
            Card gold2 = new Gold();
            tempHand.Add(gold1);
            tempHand.Add(gold2);
            p1.setHand(tempHand);
            p1.playCard(gold1); //this makes it so that you have enough money to buy the card
            p1.playCard(gold2); //same
            int moneyBefore = p1.moneyLeft();
            int cost = purchase.getPrice();
            p1.buyCard(purchase);
            Assert.AreEqual((moneyBefore - cost), p1.moneyLeft());

            
        }
        [TestMethod]
        public void buyingCheapCardTakesMoneyFromPlayer()
        {
            Player p1 = new HumanPlayer();
            Card purchase = new Estate();  //2
            ArrayList tempHand = new ArrayList();
            Card gold1 = new Gold();
            Card gold2 = new Gold();
            tempHand.Add(gold1);
            tempHand.Add(gold2);
            p1.setHand(tempHand);
            p1.playCard(gold1); //this makes it so that you have enough money to buy the card
            p1.playCard(gold2); //same
            int moneyBefore = p1.moneyLeft();
            int cost = purchase.getPrice();
            p1.buyCard(purchase);
            Assert.AreEqual((moneyBefore - cost), p1.moneyLeft());
        }

        [TestMethod]
        public void testIfUserHasTooLittleMoney()
        {
            Player p1 = new HumanPlayer();
            Card purchase = new Laboratory();  //5
            Assert.IsFalse(p1.buyCard(purchase));            
        }


        [TestMethod]
        public void testIfUserHasEnoughMoney()
        {
            Player p1 = new HumanPlayer();
            Card purchase = new Laboratory();  //5
            ArrayList tempHand = new ArrayList();
            Card gold1 = new Gold();
            Card gold2 = new Gold();
            tempHand.Add(gold1);
            tempHand.Add(gold2);
            p1.setHand(tempHand);
            p1.playCard(gold1); //this makes it so that you have enough money to buy the card
            p1.playCard(gold2); //same
            Assert.IsTrue(p1.buyCard(purchase));
                     
        }

        [TestMethod]
        public void cardNotAddedWithNotEnoughMoney()
        {
            Player p1 = new HumanPlayer();
            Card purchase = new Laboratory();
            int discardSize = p1.getDiscard().Count;
            p1.buyCard(purchase);
            Assert.AreEqual(discardSize, p1.getDiscard().Count);
        }

        [TestMethod]
        public void addCardToHand()
        {
            Player p1 = new HumanPlayer();
            p1.setHand(new ArrayList());
            int handCountBefore = p1.getHand().Count;
            p1.addCardToHand(new Library());
            Assert.AreEqual(handCountBefore + 1, p1.getHand().Count);
            Assert.IsTrue(p1.getHand().Contains(new Library()));
        }
        private void printCardStats(ActionCard c)
        {
            Console.WriteLine("cards drawn " + c.cards);
            Console.WriteLine("buys gianed " + c.buys);
            Console.WriteLine("acts gianed " + c.actions);
            Console.WriteLine("cash gianed " + c.money);
            Console.Read();
            Console.WriteLine();
        }
        [TestMethod]
        public void testCountCards()
        {
            Stack<Card> deck = new Stack<Card>();
            deck.Push(new Cellar());
            deck.Push(new Village());
            deck.Push(new Smithy());
            deck.Push(new Village());
            deck.Push(new Village());

            Dictionary<int, int> count = countCards(deck);
            Dictionary<int, int> expct = new Dictionary<int, int>();
            expct.Add(new Village().getID(), 3);
            expct.Add(new Smithy().getID(), 1);
            expct.Add(new Cellar().getID(), 1);

            CollectionAssert.AreEqual(count, expct);
        }

        [TestMethod]
        public void testPlayingAttackMakesOpponentQueueBigger()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            Player p4 = new HumanPlayer(4);
            board.AddPlayer(p1);
            board.AddPlayer(p2); 
            board.AddPlayer(p3); 
            board.AddPlayer(p4);
            int p2AttackSize = p2.getAttacks().Count;
            int p3AttackSize = p3.getAttacks().Count;
            int p4AttackSize = p4.getAttacks().Count;
            Card militia = new Militia();
            p1.getHand().Add(militia);
            p1.playCard(militia);
            Assert.AreEqual(p2AttackSize + 1, p2.getAttacks().Count);
            Assert.AreEqual(p3AttackSize + 1, p3.getAttacks().Count);
            Assert.AreEqual(p4AttackSize + 1, p4.getAttacks().Count);
        }

        [TestMethod]
        public void TestPlayerIgnoresAttacksWithMoat()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int p2AttackSize = p2.getAttacks().Count;
            int p3AttackSize = p3.getAttacks().Count;
            Card militia = new Militia();
            p1.getHand().Add(militia);
            p2.getHand().Add(new Moat());
            p1.playCard(militia);
            Assert.AreEqual(p2AttackSize, p2.getAttacks().Count);
            Assert.AreEqual(p3AttackSize + 1, p3.getAttacks().Count);
        }

        [TestMethod]
        public void TestPlayerIsSameBeforeAndAfterAttack()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            int p2AttackSize = p2.getAttacks().Count;
            int p3AttackSize = p3.getAttacks().Count;
            Card militia = new Militia();
            p1.getHand().Add(militia);
            Player before = board.turnOrder.Peek();
            p1.playCard(militia);
            Assert.AreSame(before, board.turnOrder.Peek());
            
        }

        [TestMethod]
        public void testPlayingAttackDoesNotMakeYourQueueBigger()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(cards);
            Player p1 = new HumanPlayer(1);
            Player p2 = new HumanPlayer(2);
            Player p3 = new HumanPlayer(3);
            Player p4 = new HumanPlayer(4);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            board.AddPlayer(p3);
            board.AddPlayer(p4);
            int p1AttackSize = p1.getAttacks().Count;
            Card militia = new Militia();
            p1.getHand().Add(militia);
            p1.playCard(militia);
            Assert.AreEqual(p1AttackSize, p1.getAttacks().Count);
        }

        private Dictionary<int, int> countCards(Stack<Card> deck)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            Stack<Card> temp = new Stack<Card>();

            while (deck.Count > 0)
            {
                Card c = deck.Pop();
                if (count.ContainsKey(c.getID()))
                {
                    int number = count[c.getID()] + 1;
                    count.Remove(c.getID());
                    count.Add(c.getID(), number);
                }
                else
                {
                    count.Add(c.getID(), 1);
                }
            }
            // reconstruct the deck
            while (temp.Count > 0)
            {
                deck.Push(temp.Pop());
            }
            return count;
        }


    }
}
