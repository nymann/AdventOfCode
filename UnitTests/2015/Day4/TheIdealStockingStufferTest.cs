using AdventOfCode._2015.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day4
{
    [TestClass]
    public class TheIdealStockingStufferTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new TheIdealStockingStuffer();
            Assert.AreEqual(609043, problem.Part1("abcdef"));
            Assert.AreEqual(1048970, problem.Part1("pqrstuv"));
        }

        [TestMethod]
        public void Part2Test()
        {

        }
    }
}