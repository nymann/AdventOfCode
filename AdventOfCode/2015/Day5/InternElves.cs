using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day5
{
    public class InternElves
    {
        public int Part1(List<string> input)
        {
            return input.Count(IsNicePart1);
        }

        public int Part2(List<string> input)
        {
            return input.Count(IsNicePart2);
        }

        private bool IsNicePart1(string input)
        {
            // does not contain the pairs:
            // ab, cd, pq, xy
            if (input.Contains("ab") || input.Contains("cd") || input.Contains("pq") || input.Contains("xy"))
            {
                return false;
            }

            // atleast 3 vowels
            // atleast 1 Double letter
            var vowelCounter = 0;
            var doubleLetter = false;
            var vowels = new List<char> {'a', 'e', 'i', 'o', 'u'};

            for (var index = 0; index < input.Length; index++)
            {
                var c = input[index];
                if (!doubleLetter && index + 1 < input.Length && c == input[index + 1])
                {
                    doubleLetter = true;
                }

                if (vowels.Contains(c))
                {
                    vowelCounter++;
                }
            }

            return doubleLetter && vowelCounter > 2;
        }

        private bool IsNicePart2(string input)
        {
            // 
            var c1 = false;
            var c2 = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (!c1 && i + 3 < input.Length)
                {
                    var pair = input[i] + input[i + 1].ToString();
                    var substring = input.Substring(i + 2);
                    if (substring.Contains(pair))
                    {
                        c1 = true;
                    }
                }

                if (!c2 && i + 2 < input.Length && input[i].Equals(input[i + 2]))
                {
                    c2 = true;
                }
            }

            return c1 && c2;
        }
    }
}