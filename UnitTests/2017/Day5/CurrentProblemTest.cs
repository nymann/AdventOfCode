using AdventOfCode._2017.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day5
{
    [TestClass]
    public class CurrentProblemTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new CurrentProblem();
            Assert.AreEqual(0, problem.Part1(""));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new CurrentProblem();
            Assert.AreEqual(0, problem.Part2(""));
        }
    }
}