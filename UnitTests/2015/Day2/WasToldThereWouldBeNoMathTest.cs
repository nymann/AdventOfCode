using System.Collections.Generic;
using AdventOfCode._2015.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day2
{
    [TestClass]
    public class WasToldThereWouldBeNoMathTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new WasToldThereWouldBeNoMath();
            Assert.AreEqual(58, problem.Part1(new List<string> {"2x3x4"}));
            Assert.AreEqual(43, problem.Part1(new List<string> {"1x1x10"}));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new WasToldThereWouldBeNoMath();
            Assert.AreEqual(34, problem.Part2(new List<string> { "2x3x4" }));
            Assert.AreEqual(14, problem.Part2(new List<string> { "1x1x10" }));
        }
    }
}