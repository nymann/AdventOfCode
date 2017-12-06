using AdventOfCode._2016.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day5
{
    [TestClass]
    public class HowAboutANiceGameOfChessTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new HowAboutANiceGameOfChess();
            Assert.AreEqual("18f47a30", problem.Part1("abc"));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new HowAboutANiceGameOfChess();
            Assert.AreEqual("05ace8e3", problem.Part2("abc"));
        }
    }
}