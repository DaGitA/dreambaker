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
            GameController gameController = new GameController();
            gameController.crazynessLevelText = "bob";
            Assert.IsTrue(true);
        }
    }
}
