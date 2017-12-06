using System.Collections.Generic;
using AdventOfCode._2016.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day3
{
    [TestClass]
    public class SquaresWithThreeSidesTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new SquaresWithThreeSides();
            Assert.AreEqual(0, problem.Part1(new List<string>{ "5 10 25" }));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new SquaresWithThreeSides();
            var input = new List<string>
            {
                "101 301 501",
                "102 302 502",
                "103 303 503",
                "201 401 601",
                "202 402 602",
                "203 403 603"
            };
            Assert.AreEqual(6, problem.Part2(input));
        }
    }
}