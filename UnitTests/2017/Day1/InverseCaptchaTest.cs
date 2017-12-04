using AdventOfCode._2017.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2017.Day1
{
    [TestClass]
    public class InverseCaptchaTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new InverseCaptcha();
            Assert.AreEqual(3, problem.Part1("1122"));
            Assert.AreEqual(4, problem.Part1("1111"));
            Assert.AreEqual(0, problem.Part1("1234"));
            Assert.AreEqual(9, problem.Part1("91212129"));
        }

        [TestMethod]
        public void Part2Test()
        {
            var problem = new InverseCaptcha();
            Assert.AreEqual(6, problem.Part2("1212"));
            Assert.AreEqual(0, problem.Part2("1221"));
            Assert.AreEqual(4, problem.Part2("123425"));
            Assert.AreEqual(12, problem.Part2("123123"));
            Assert.AreEqual(4, problem.Part2("12131415"));
        }
    }
}