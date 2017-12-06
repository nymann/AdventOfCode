using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day7
{
    public class InternetProtocolVersion7
    {
        #region Part 1

        public int Part1(List<string> input)
        {
            return input.Count(SupportsTransportlayerSnooping);
        }

        #endregion


        #region Part 2

        public int Part2List(List<string> input)
        {
            return 0;
        }

        #endregion


        private bool SupportsTransportlayerSnooping(string ip)
        {
            // rhamaeovmbheijj[hkwbkqzlcscwjkyjulk]ajsxfuemamuqcjccbc
            // Get within brackets
            var matches = Regex.Matches(ip, @"\[(.*?)\]"); // [hkwbkqzlcscwjkyjulk]

            var s = ip.Substring(0, ip.IndexOf('[')); // rhamaeovmbheijj
            

            return true;
        }
    }
}