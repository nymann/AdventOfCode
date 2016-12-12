using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Day5
{
    public class HowAboutANiceGameOfChess
    {
        private int _counter = 0;

        public HowAboutANiceGameOfChess(string input)
        {
            var startTime = new Stopwatch();
            startTime.Start();
            StringBuilder password = new StringBuilder();

            while (password.Length < 8)
            {
                var temp = input + _counter;
                if (DoesMd5HashStartWithFive0s(temp))
                {
                    char c = GetNextPasswordCharacter(temp);
                    password.Append(c);
                    Console.WriteLine("Found next password char, it is: {0}.", c);
                }

                _counter++;
            }
            startTime.Stop();
            Console.WriteLine("password is: {0}, computed in {1} ms.", password, startTime.ElapsedMilliseconds);
            Console.ReadKey();
        }

        private bool DoesMd5HashStartWithFive0s(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var stringBuilder = new StringBuilder();

                foreach (var t in hashBytes)
                {
                    stringBuilder.Append(t.ToString("x2"));

                    if (stringBuilder.Length > 5)
                    {
                        return stringBuilder.ToString().Substring(0, 5).Equals("00000");
                    }

                    var compareTo = new string('0', stringBuilder.Length);
                    if (!stringBuilder.ToString().Substring(0, stringBuilder.Length).Equals(compareTo))
                    {
                        return false;
                    }
                }

                return stringBuilder.ToString().Substring(0, 5).Equals("00000");
            } ;
            
        }

        private char GetNextPasswordCharacter(string hash)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(hash);
                var hashBytes = md5.ComputeHash(inputBytes);

                var stringBuilder = new StringBuilder();

                foreach (var t in hashBytes)
                {
                    stringBuilder.Append(t.ToString("x2"));
                }
                return stringBuilder.ToString()[5];
            };
        }
    }
}