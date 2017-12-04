using System.Collections.Generic;
using AdventOfCode._2017.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day2
{
    [TestClass]
    public class CorruptionChecksumTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new CorruptionChecksum();
            var input = new List<string>
            {   "5\t1\t9\t5",
                "7\t5\t3",
                "2\t4\t6\t8" 
            };

            Assert.AreEqual(18, problem.Part1(input));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new CorruptionChecksum();
            var input = new List<string>
            {   "5\t9\t2\t8",
                "9\t4\t7\t3",
                "3\t8\t6\t5"
            };

            Assert.AreEqual(9, problem.Part2(input));
        }
    }
}