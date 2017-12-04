using System.Collections.Generic;
using AdventOfCode._2015.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day7
{
    [TestClass]
    public class SomeAssemblyRequiredTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new SomeAssemblyRequired();
            var instructions = new List<string>
            {
                "123 -> x",
                "456 -> y",
                "x AND y -> d",
                "x OR y -> e",
                "x LSHIFT 2 -> f",
                "y RSHIFT 2 -> g",
                "NOT x -> h",
                "NOT y -> i"
            };

            Assert.AreEqual(72, problem.Part1(instructions, "d"));
            Assert.AreEqual(507, problem.Part1(instructions, "e"));
            Assert.AreEqual(492, problem.Part1(instructions, "f"));
            Assert.AreEqual(114, problem.Part1(instructions, "g"));
            Assert.AreEqual(65412, problem.Part1(instructions, "h"));
            Assert.AreEqual(65079, problem.Part1(instructions, "i"));
            Assert.AreEqual(123, problem.Part1(instructions, "x"));
            Assert.AreEqual(456, problem.Part1(instructions, "y"));
        }
    }
}