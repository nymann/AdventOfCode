using System.Collections.Generic;
using AdventOfCode._2017.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day5
{
    [TestClass]
    public class MazeOfTwistyTrampolinesTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new MazeOfTwistyTrampolines();
            var input = new List<string>
            {
                "0",
                "3",
                "0",
                "1",
                "-3"
            };

            Assert.AreEqual(5, problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new MazeOfTwistyTrampolines();
            var input = new List<string>
            {
                "0",
                "3",
                "0",
                "1",
                "-3"
            };
            Assert.AreEqual(10, problem.Part2(input));
        }
    }
}