using System.Collections.Generic;
using AdventOfCode._2016.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day6
{
    [TestClass]
    public class SignalsAndNoiseTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new SignalsAndNoise();
            var input = new List<string>
            {
                "eedadn",
                "drvtee",
                "eandsr",
                "raavrd",
                "atevrs",
                "tsrnev",
                "sdttsa",
                "rasrtv",
                "nssdts",
                "ntnada",
                "svetve",
                "tesnvt",
                "vntsnd",
                "vrdear",
                "dvrsen",
                "enarar"
            };

            Assert.AreEqual("easter", problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new SignalsAndNoise();
            var input = new List<string>
            {
                "eedadn",
                "drvtee",
                "eandsr",
                "raavrd",
                "atevrs",
                "tsrnev",
                "sdttsa",
                "rasrtv",
                "nssdts",
                "ntnada",
                "svetve",
                "tesnvt",
                "vntsnd",
                "vrdear",
                "dvrsen",
                "enarar"
            };

            Assert.AreEqual("advent", problem.Part2(input));
        }
    }
}