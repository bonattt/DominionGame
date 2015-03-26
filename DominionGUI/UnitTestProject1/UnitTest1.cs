using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(80, 80);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreNotEqual(23, 80);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsFalse(false);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsNull(null, null);
        }
    }
}
