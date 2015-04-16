using System;
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
            List<int> theList = GenerateRandom.GenerateRandomList(15);
            Boolean israndom =  theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true,israndom);
        }
        [Test()]
        public void testRandomList2()
        {
            List<int> theList = GenerateRandom.GenerateRandomList(100);
            Boolean israndom = theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true, israndom);
        }

        [Test()]
        public void testSelectRandomWhenStartGame()
        {
            List<int> theList = GenerateRandom.GenerateRandomList(25);
            Boolean israndom = theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true, israndom);
        }

    }
}
