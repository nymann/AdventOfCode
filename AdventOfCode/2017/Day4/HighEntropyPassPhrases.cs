using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day4
{
    public class HighEntropyPassPhrases
    {
        public int Part1(List<string> input)
        {
            return input.Count(IsValidPart1);
        }

        public int Part2(List<string> input)
        {
            return input.Count(IsValidPart2);
        }

        private bool IsValidPart1(string passphrase)
        {
            var split = passphrase.Split(' ');
            var usedWords = new List<string>();
            foreach (var s in split)
            {
                if (usedWords.Contains(s))
                {
                    return false;
                }

                usedWords.Add(s);
            }

            return true;
        }

        private bool IsValidPart2(string passphrase)
        {
            var split = passphrase.Split(' ');
            var usedWords = new List<string>();
            foreach (var s in split)
            {
                if (usedWords.Any(usedWord => IsAnagramSimple(s, usedWord)))
                {
                    return false;
                }

                usedWords.Add(s);
            }

            return true;
        }

        private bool IsAnagramSimple(string a, string b)
        {
            return a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
        }
    }
}