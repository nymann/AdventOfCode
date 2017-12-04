using AdventOfCode._2015.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2015.Day1
{
    [TestClass]
    public class NotQuiteLispTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var notQuiteLisp = new NotQuiteLisp();
            Assert.AreEqual(0, notQuiteLisp.Part1("(())"));
            Assert.AreEqual(0, notQuiteLisp.Part1("()()"));
            Assert.AreEqual(3, notQuiteLisp.Part1("((("));
            Assert.AreEqual(3, notQuiteLisp.Part1("(()(()("));
            Assert.AreEqual(3, notQuiteLisp.Part1("))((((("));
            Assert.AreEqual(-1, notQuiteLisp.Part1("())"));
            Assert.AreEqual(-1, notQuiteLisp.Part1("))("));
            Assert.AreEqual(-3, notQuiteLisp.Part1(")))"));
            Assert.AreEqual(-3, notQuiteLisp.Part1(")())())"));
        }

        [TestMethod]
        public void Part2Test()
        {
            var notQuiteLisp = new NotQuiteLisp();
            Assert.AreEqual(1, notQuiteLisp.Part2(")"));
            Assert.AreEqual(5, notQuiteLisp.Part2("()())"));
        }
    }
}