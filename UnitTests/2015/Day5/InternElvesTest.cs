using System.Collections.Generic;
using AdventOfCode._2015.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day5
{
    [TestClass]
    public class InternElvesTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new InternElves();
            Assert.AreEqual(1, problem.Part1(new List<string> {"ugknbfddgicrmopn"}));
            Assert.AreEqual(1, problem.Part1(new List<string> {"aaa"}));
            Assert.AreEqual(0, problem.Part1(new List<string> {"jchzalrnumimnmhp"}));
            Assert.AreEqual(0, problem.Part1(new List<string> {"haegwjzuvuyypxyu"}));
            Assert.AreEqual(0, problem.Part1(new List<string> {"dvszwmarrgswjxmb"}));
        }

        [TestMethod]
        public void Part2Test()
        {
        }
    }
}