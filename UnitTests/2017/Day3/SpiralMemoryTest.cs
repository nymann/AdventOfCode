using AdventOfCode._2017.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day3
{
    [TestClass]
    public class SpiralMemoryTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new SpiralMemory();
            Assert.AreEqual(0, problem.Part1(1));
            Assert.AreEqual(3, problem.Part1(12));
            Assert.AreEqual(2, problem.Part1(23));
            Assert.AreEqual(31, problem.Part1(1024));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new SpiralMemory();
            Assert.AreEqual(5, problem.Part2(4));
            Assert.AreEqual(4, problem.Part2(2));
            Assert.AreEqual(23, problem.Part2(22));
            Assert.AreEqual(54, problem.Part2(51));
        }
    }
}