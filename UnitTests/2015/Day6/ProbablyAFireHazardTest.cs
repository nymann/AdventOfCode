using System.Collections.Generic;
using AdventOfCode._2015.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day6
{
    [TestClass]
    public class ProbablyAFireHazardTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new ProbablyAFireHazard();
            Assert.AreEqual(2, problem.Part1(new List<string> {"turn on 0,0 through 0,1"}));
            Assert.AreEqual(1000, problem.Part1(new List<string> {"toggle 0,0 through 999,0"}));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new ProbablyAFireHazard();
            Assert.AreEqual(1, problem.Part2(new List<string> {"turn on 0,0 through 0,0"}));
            Assert.AreEqual(2000000, problem.Part2(new List<string> {"toggle 0,0 through 999,999"}));
        }
    }
}