using System.Collections.Generic;
using AdventOfCode._2017.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day7
{
    [TestClass]
    public class RecursiveCircusTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new RecursiveCircus();
            var input = new List<string>
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };

            Assert.AreEqual("tknk", problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new RecursiveCircus();

            var input = new List<string>
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };

            Assert.AreEqual("xD", problem.Part2(input));
        }
    }
}