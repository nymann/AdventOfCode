using System.Collections.Generic;
using AdventOfCode._2016.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests._2016.Day4
{
    [TestClass]
    public class SecurityThroughObscurityTest
    {
        [TestMethod]
        public void Part1Test()
        {
            var problem = new SecurityThroughObscurity();
            var input = new List<string>
            {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "a-b-c-d-e-f-g-h-987[abcde]",
                "not-a-real-room-404[oarel]",
                "totally-real-room-200[decoy]"
            };
            Assert.AreEqual(1514, problem.Part1(input));
        }
    }
}