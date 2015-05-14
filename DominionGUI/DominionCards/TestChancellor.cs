using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DominionCards.KingdomCards;

namespace DominionCards
{
    class TestChancellor
    {
        public static void main(string[] args)
        {
            Dictionary<Card, int> dict = new Dictionary<Card, int>();
            GameBoard board = new GameBoard(dict);
            Player p1 = new HumanPlayer(1);
            p1.setHand(new ArrayList());
            board.AddPlayer(p1);
            Card card = new Chancellor();
            p1.addCardToHand(card);
            if (!TestSelectingYes(p1))
            {
                MessageBox.Show("YOU FAILLED THE TEST!!!");
            }
            if (!TestSelectingNo(p1))
            {
                MessageBox.Show("YOU FAILLED THE TEST!!!");
            }
        }

        private static int TestPlayingChancellor(Player p1)
        {
            p1.setDiscard(new ArrayList());
            Card card = new Chancellor();
            p1.addCardToHand(card);

            int deckCount = p1.getDeck().Count;
            int discardCount = p1.getDiscard().Count;

            p1.playCard(card);

            return deckCount + discardCount;
        }

        public static bool TestSelectingYes(Player p1)
        {
            int value = TestPlayingChancellor(p1);

            return (p1.getDiscard().Count == value);
        }
        public static bool TestSelectingNo(Player p1)
        {
            MessageBox.Show("press NO on the following dialogue");
            int discardCount = p1.getDiscard().Count;
            TestPlayingChancellor(p1);
            return (p1.getDiscard().Count == discardCount);
        }
    }
}
