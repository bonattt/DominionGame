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
        public void testRandom1()
        {
            List<int> theList = GenerateRandom.GenerateRandomList();
            Boolean israndom =  theList.Distinct().Count() == theList.Count();
            Assert.AreEqual(true,israndom);
        }

    }
}
