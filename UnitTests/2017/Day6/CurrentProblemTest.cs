using System.Collections.Generic;
using AdventOfCode._2017.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day6
{
    [TestClass]
    public class CurrentProblemTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var input = new List<string>
            {
                "",
                "",
            };

            var problem = new CurrentProblem();

            Assert.AreEqual(0, problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var input = new List<string>
            {
                "",
                "",
            };

            var problem = new CurrentProblem();
            Assert.AreEqual(0, problem.Part2(input));
        }
    }
}