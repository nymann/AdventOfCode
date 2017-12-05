using AdventOfCode._2016.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day1
{
    [TestClass]
    public class NoTimeForATaxiCabTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new NoTimeForATaxiCab();
            Assert.AreEqual(5, problem.Part1("R2, L3"));
            Assert.AreEqual(2, problem.Part1("R2, R2, R2"));
            Assert.AreEqual(12, problem.Part1("R5, L5, R5, R3"));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new NoTimeForATaxiCab();
            Assert.AreEqual(4, problem.Part2("R8, R4, R4, R8"));
        }
    }
}