using System.Collections.Generic;
using AdventOfCode._2017.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day4
{
    [TestClass]
    public class HighEntropyPassPhrasesTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new HighEntropyPassPhrases();
            Assert.AreEqual(1, problem.Part1(new List<string> {"aa bb cc dd ee"}));
            Assert.AreEqual(0, problem.Part1(new List<string> {"aa bb cc dd aa"}));
            Assert.AreEqual(1, problem.Part1(new List<string> {"aa bb cc dd aaa"}));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new HighEntropyPassPhrases();
            Assert.AreEqual(1, problem.Part2(new List<string> {"abcde fghij"}));
            Assert.AreEqual(0, problem.Part2(new List<string> {"abcde xyz ecdab"}));
            Assert.AreEqual(1, problem.Part2(new List<string> {"a ab abc abd abf abj"}));
            Assert.AreEqual(1, problem.Part2(new List<string> {"iiii oiii ooii oooi oooo"}));
            Assert.AreEqual(0, problem.Part2(new List<string> {"oiii ioii iioi iiio"}));
        }
    }
}