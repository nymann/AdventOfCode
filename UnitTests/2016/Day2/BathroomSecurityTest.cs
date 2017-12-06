using System.Collections.Generic;
using AdventOfCode._2016.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day2
{
    [TestClass]
    public class BathroomSecurityTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new BathroomSecurity();
            var input = new List<string> {"ULL", "RRDDD", "LURDL", "UUUUD"};
            Assert.AreEqual("1985", problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new BathroomSecurity();
            var input = new List<string> { "ULL", "RRDDD", "LURDL", "UUUUD" };
            Assert.AreEqual("5DB3", problem.Part2(input));
        }
    }
}