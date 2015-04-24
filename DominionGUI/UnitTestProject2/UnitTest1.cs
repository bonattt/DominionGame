using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void before()
        {
            Console.WriteLine("\nrunning test...");
        }
        [TestMethod]
        public void test1is1()
        {
            Console.WriteLine("test 1");
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        public void test2plus2()
        {
            Console.WriteLine("test 2");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void test3()
        {
            Console.WriteLine("test 3");
            Assert.Fail();
        }
        [TestCleanup]
        public void after()
        {
            Console.WriteLine("test complete!");
        }

    }
}
