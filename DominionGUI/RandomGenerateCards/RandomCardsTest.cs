using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RandomGenerateCards
{
    [TestFixture()]
    class RandomCardsTest
    {
        [Test()]
        public void testRandomList1()
        {
            List<int> theList = GenerateRandom.GenerateRandomList(25,15);
            Boolean israndom =  theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true,israndom);
        }
        [Test()]
        public void testRandomList2()
        {
            List<int> theList = GenerateRandom.GenerateRandomList(100,10);
            Boolean israndom = theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true, israndom);
        }

        [Test()]
        public void testSelectRandomWhenStartGame()
        {
            List<int> theList = GenerateRandom.GenerateRandomList(25,5);
            Boolean israndom = theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true, israndom);
        }

        [Test()]
        public void testSuffleDeck()
        {
            ArrayList theList = new ArrayList();
            theList.Add(4);
            theList.Add(5);
            theList.Add(11);
            theList.Add(15);
            theList.Add(29);

            Stack olddeck = new Stack();

            for (int i = 0; i < theList.Capacity; i++)
            {
                olddeck.Push(theList[i]);
            }


            Stack randomdeck = GenerateRandom.SuffleDeck(theList);

            Boolean israndom = true;
            for (int i = 0; i < olddeck.Count; i++)
            {
                if (olddeck.Pop() == randomdeck.Pop())
                    israndom = false;
                else
                    israndom = true;
            }
            Assert.AreEqual(true, israndom);
        }
    }
}
