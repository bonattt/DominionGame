using DominionCards.KingdomCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DominionCards
{
    public class AIplayer : Player
    {
        int victory, treasure, actionGain, other; // how many of each type of these card are currently in the AI player's dack.
        double avgTreasureValue;
        bool attacksAvailible = false;

        List<Card> sortedBuyableCards;


        public AIplayer(int numb)
            : base(numb)
        {
            List<Card> list = GameBoard.getInstance().GetCards().Keys.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsAttack())
                {
                    attacksAvailible = true;
                    break;
                }
            }
            sortedBuyableCards = SortCards(list, 4, 2);
            FilterCardsNeverToBuy();
        }
        public List<Card> GetBestPriceRange(int price)
        {
            int i = sortedBuyableCards.Count / 2;
            int increment = i / 2;
            int lastjump = 0;
            int thisjump = 0;
            while (i < sortedBuyableCards.Count && i >= 0)
            {
                if (sortedBuyableCards[i].getPrice() > price)
                {
                    lastjump = thisjump;
                    thisjump = increment;
                    i += increment;
                }
                else if (sortedBuyableCards[i].getPrice() < price)
                {
                    lastjump = thisjump;
                    thisjump = -increment;
                    i -= increment;
                }
                else {
                    break;
                }

                if (lastjump + thisjump == 0) // if you've entered and infinite loop.
                {
                    break;
                } 
                increment -= increment / 2;
            }

            if (sortedBuyableCards[i].getPrice() != price)
            {
                return GetBestPriceRange(price - 1);
            }

            List<Card> list = ScanList(price, i, -1);
            list.AddRange(ScanList(price, i, 1));
            list.Add(sortedBuyableCards[i]);
            return list;
        }
        /**
         * helper method, scans the given list from the given start point and returns a list of all the cards
         * in the direction of the increment that have the given price, not including the start point.
         */
        private List<Card> ScanList(int price, int startPoint, int increment)
        {
            List<Card> selected = new List<Card>();
            for (int i = startPoint+increment; (i < sortedBuyableCards.Count && i >= 0); i += increment)
            {
                if (sortedBuyableCards[i].getPrice() != price){
                    break; // once ouride the target price range, break.
                }
                selected.Add(sortedBuyableCards[i]);
            }
            return selected;
        }

        private List<Card> GetWillingToTrash()
        {
            List<Card> trashable = new List<Card>();
            trashable.Add(new Estate());
            trashable.Add(new Curse());

            if (GetRationOf(treasure) > .5 && avgTreasureValue >= 1.5)
            {
                trashable.Add(new Copper());
            }
            else if (avgTreasureValue >= 2)
            {
                trashable.Add(new Copper());
            }
            return trashable;
        }
        private void FilterCardsNeverToBuy()
        {
            sortedBuyableCards.Remove(new Curse());         // never buy a curse.
            sortedBuyableCards.Remove(new Chancellor());    // never buy a chancellor.
            sortedBuyableCards.Remove(new MoneyLender());   // never buy a money lender.
            sortedBuyableCards.Remove(new Thief());         // never buy a Thief.

            if (!sortedBuyableCards.Contains(new Witch()))  // unless there are witches, do not buy chapels.
            {
                sortedBuyableCards.Remove(new Chapel());
            }
        }

        public double GetRationOf(int cardType)
        {
            return cardType / (double) GetTotalCards();
        }


        public int GetTotalActionCards()
        {
            return actionGain + other;
        }

        public int GetTotalCards()
        {
            return getDeck().Count + getDiscard().Count + getHand().Count;
        }

        public override void actionPhase()
        {
            List<ActionCard> playableCards = new List<ActionCard>();// cardToBePlayed;
            Thread.Sleep(100);
            for (int i = 0; i < getHand().Count; i++)
            {
                if (((Card)getHand()[i]).IsAction())
                {
                    playableCards.Add((ActionCard)getHand()[i]);
                }
            }
            if (playableCards.Count == 0)
            {
                Console.WriteLine("AI-Player: No action cards left, aborting action phase!");
                return;
            }
            playCard(selectByActions(playableCards));
            Thread.Sleep(100);
        }
        public ActionCard selectByActions(List<ActionCard> playableCards)
        {
            ActionCard currentSelection = playableCards[0];
            for (int i = 1; i < playableCards.Count; i++)
            {
                ActionCard card = playableCards[i];
                
                if (card.actions > currentSelection.actions)
                {
                    currentSelection = card;
                    continue;
                }
                if (card.actions == currentSelection.actions)
                {
                    if (card.Equals(currentSelection))
                    {
                        continue;
                    }
                    if (actionsLeft() >= 2)
                    {
                        List<ActionCard> tempList = new List<ActionCard>();
                        tempList.Add(card);
                        tempList.Add(currentSelection);
                        currentSelection = selectByDraws(tempList);
                    }
                    else
                    {
                        List<ActionCard> tempList = new List<ActionCard>();
                        tempList.Add(card);
                        tempList.Add(currentSelection);
                        currentSelection = selectByMoney(tempList);
                    }
                }
            }
            return currentSelection;
        }
        public void updateAvgTreasure(int newCoin)
        {
            double totalTreatureValue = (avgTreasureValue * treasure) + newCoin;
            treasure += 1;
            avgTreasureValue = totalTreatureValue / treasure;
            
        }

        private ActionCard selectByMoney(List<ActionCard> playableCards)
        {
            ActionCard currentSelection = playableCards[0];
            for (int i = 1; i < playableCards.Count; i++)
            {
                ActionCard card = playableCards[i];
                if (card.getPrice() > currentSelection.getPrice())
                {
                    currentSelection = card;
                    continue;
                }
                if (card.getPrice() == currentSelection.getPrice())
                {
                    if (card.money > currentSelection.money)
                    {
                        currentSelection = card;
                        continue;
                    }
                    if (card.money == currentSelection.money)
                    {
                        if (card.cards > currentSelection.cards)
                        {
                            currentSelection = card;
                            continue;
                        }
                    }
                }
            }
            return currentSelection;
        }
        private ActionCard selectByDraws(List<ActionCard> playableCards)
        {
            ActionCard currentSelection = playableCards[0];
            for (int i = 1; i < playableCards.Count; i++)
            {
                ActionCard card = playableCards[i];
                if (card.cards > currentSelection.cards)
                {
                    currentSelection = card;
                    continue;
                }
                if (card.cards == currentSelection.cards)
                {
                    if (card.getPrice() > currentSelection.getPrice())
                    {
                        currentSelection = card;
                    }
                }
            }
            return currentSelection;
        }


        public override void buyPhase()
        {
            int priceRange = moneyLeft();
            bool buySuccessful;
            do
            {
                buySuccessful = BuyPhaseHelper(priceRange);
                priceRange -= 1;
            } while (!buySuccessful && priceRange >= 0);
            if (priceRange == -1)
            {
                Console.WriteLine("AI-Player: could not find any cards to buy, ending buy phase.");
                buys = 0;
            }
            
        }
        private bool BuyPhaseHelper(int moneyLeft)
        {
            List<Card> priceRange = GetBestPriceRange(moneyLeft);
            List<Card> priorities = GetPriorities();
            for (int i = 0; i < priorities.Count; i++)
            {
                Card c = priorities[i];
                if (priceRange.Contains(c))
                {
                    bool buySuccessful = buyCard(c);
                    if (buySuccessful) // if buy successful
                    {
                        string str = "AI player " + getNumber() + " bought a " + c;
                        Console.WriteLine(str);
                        // TODO popup a window.
                        return true;
                    }
                }
            }
            // if no priority cards availible, buy a random card.
            Random r = new Random();
            while (priceRange.Count > 0)
            {
                int index = r.Next(0, priceRange.Count);
                bool buySuccessful = buyCard(priceRange[index]);
                if (buySuccessful)
                {
                    string str = "AI player " + getNumber() + " bought a " + priceRange[index];
                    Console.WriteLine(str);
                    // TODO popup a window.
                    return true;
                }
                priceRange.Remove(priceRange[index]);
            }
            return false;
        }

        private bool BuyACard(int price)
        {
            return false;
        }

        public List<Card> GetPriorities()
        {
            List<Card> priorities = new List<Card>();
            if (attacksAvailible)
            {
                priorities.Add(new Moat());
            }

            if (GetRationOf(treasure) < .5)
            {
                priorities.Add(new Silver());
            }

            if (GetRationOf(treasure) < .5 && avgTreasureValue >= 2)
            {
                priorities.Add(new Adventurer());
            }

            if (GetRationOf(victory) < .05)
            {
                priorities.Add(new Duchy());
            }

            if (GetRationOf(victory) < .05 && GetTotalCards() >= 30)
            {
                priorities.Add(new Gardens());
            }
            if (GetRationOf(victory) < .10 && GetTotalCards() >= 50)
            {
                priorities.Add(new Gardens());
            }

            if (GetRationOf(actionGain) < .05)
            {

            }


            return priorities;
        }
        public override bool buyCard(Card card)
        {
            if (card.IsTreasure())
            {
                updateAvgTreasure(((TreasureCard)card).getValue());
            }
            else if (card.IsVictory())
            {
                victory += 1;
            }
            else
            {

            }

            return base.buyCard(card);
        }

        public override ArrayList SelectCards(ArrayList cards, String name, int numCards)
        {
            // TODO ////////////////////////////////////////////////////////
            return null;
        }

        public static List<Card> SortCards(List<Card> unsortedList, int middle, int increment)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }
            bool listIsSorted = true;
            List<Card> cheap = new List<Card>();
            List<Card> expensive = new List<Card>();

            int firstPrice = unsortedList[0].getPrice();
            for (int i = 0; i < unsortedList.Count; i++)
            {
                if (unsortedList[i].getPrice() != firstPrice)
                {
                    listIsSorted = false;
                }


                if (unsortedList[i].getPrice() < middle)
                {
                    cheap.Add(unsortedList[i]);
                }
                else
                {
                    expensive.Add(unsortedList[i]);
                }
            }
            if (!listIsSorted)
            {
                cheap = SortCards(cheap, middle -increment, 1);
                expensive = SortCards(expensive, middle + increment, 1);
            }
            expensive.AddRange(cheap);
            return expensive;
        }

    }
}
