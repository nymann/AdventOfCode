using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2016.Day5
{
    public class HowAboutANiceGameOfChess
    {
        public string Part1(string input)
        {
            using (var md5 = MD5.Create())
            {
                var password = "";
                for (var i = 0; i < int.MaxValue; i++)
                {
                    var str = input + i;
                    var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    if (!HexStartsWithXZeroes(hex, 5))
                    {
                        continue;
                    }

                    password += hex[5];

                    if (password.Length == 8)
                    {
                        return password.ToLower();
                    }
                }
            }

            throw new Exception("No solutions found!");
        }

        public string Part2(string input)
        {
            using (var md5 = MD5.Create())
            {
                var password = "________";
                for (var i = 0; i < int.MaxValue; i++)
                {
                    var str = input + i;
                    var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    var index = Convert.ToInt32(hex[5] - '0');
                    if (index > 7 || !password[index].Equals('_'))
                    {
                        continue;
                    }
                    if (!HexStartsWithXZeroes(hex, 5))
                    {
                        continue;
                    }

                    password = new StringBuilder(password) {[index] = hex[6]}.ToString();
                    if (!password.Contains("_"))
                    {
                        return password.ToLower();
                    }
                }
            }

            throw new Exception("No solutions found!");
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