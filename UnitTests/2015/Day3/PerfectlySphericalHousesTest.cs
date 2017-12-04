using AdventOfCode._2015.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day3
{
    [TestClass]
    public class PerfectlySphericalHousesTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new PerfectlySphericalHouses();
            Assert.AreEqual(2, problem.Part1(">"));
            Assert.AreEqual(4, problem.Part1("^>v<"));
            Assert.AreEqual(2, problem.Part1("^v^v^v^v^v"));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new PerfectlySphericalHouses();
            Assert.AreEqual(3, problem.Part2("^v"));
            Assert.AreEqual(3, problem.Part2("^>v<"));
            Assert.AreEqual(11, problem.Part2("^v^v^v^v^v"));
        }
    }
}