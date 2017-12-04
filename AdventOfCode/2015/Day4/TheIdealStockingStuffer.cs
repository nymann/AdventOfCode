using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2015.Day4
{
    public class TheIdealStockingStuffer
    {
        public int Part1(string input)
        {
            using (var md5 = MD5.Create())
            {
                for (var i = 0; i < int.MaxValue; i++)
                {
                    var str = input + i;
                    var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    if (HexStartsWithXZeroes(hex, 5))
                    {
                        return i;
                    }
                }
            }

            throw new Exception("Couldn't find a solution!");
        }

        public int Part2(string input)
        {
            using (var md5 = MD5.Create())
            {
                for (var i = 0; i < int.MaxValue; i++)
                {
                    var str = input + i;
                    var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    if (HexStartsWithXZeroes(hex, 6))
                    {
                        return i;
                    }
                }
            }

            throw new Exception("Couldn't find a solution!");
        }

        private bool HexStartsWithXZeroes(string input, int x)
        {
            for (var i = 0; i < x; i++)
            {
                if (!input[i].Equals('0'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}