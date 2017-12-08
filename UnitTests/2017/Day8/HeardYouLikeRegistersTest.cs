using System.Collections.Generic;
using AdventOfCode._2017.Day8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day8
{
    [TestClass]
    public class HeardYouLikeRegistersTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var input = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            var problem = new HeardYouLikeRegisters();
            Assert.AreEqual(1, problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var input = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            var problem = new HeardYouLikeRegisters();
            Assert.AreEqual(10, problem.Part2(input));
        }
    }
}