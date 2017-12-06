using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day6
{
    public class MemoryReallocation
    {
        public object Part1(string input)
        {
            var matches = Regex.Matches(input, @"([0-9])+");
            var blocks = (from Match match in matches
                select Convert.ToInt32(match.Value)).ToList();

            var histogram =
                new HashSet<string>
                {
                    ListToString(blocks)
                }; // if we try to add a duplicate, then the histogram.Count won't change since HashSet doesn't allow duplicates.

            while (true)
            {
                var maxValue = blocks.Max();
                var maxIndex = blocks.IndexOf(maxValue);
                var toDistribute = blocks[maxIndex];
                var counter = 1;
                blocks[maxIndex] = 0;

                while (toDistribute > 0)
                {
                    blocks[(maxIndex + counter) % blocks.Count]++;
                    toDistribute--;
                    counter++;
                }

                var x = histogram.Count;
                histogram.Add(ListToString(blocks));
                if (x == histogram.Count)
                {
                    return histogram.Count;
                }
            }

            throw new Exception("Couldn't find a solution");
        }

        public object Part2(string input)
        {
            var matches = Regex.Matches(input, @"([0-9])+");
            var blocks = (from Match match in matches
                select Convert.ToInt32(match.Value)).ToList();

            var histogram =
                new HashSet<string>
                {
                    ListToString(blocks)
                }; // if we try to add a duplicate, then the histogram.Count won't change since HashSet doesn't allow duplicates.

            while (true)
            {
                var maxValue = blocks.Max();
                var maxIndex = blocks.IndexOf(maxValue);
                var toDistribute = blocks[maxIndex];
                var counter = 1;
                blocks[maxIndex] = 0;

                while (toDistribute > 0)
                {
                    blocks[(maxIndex + counter) % blocks.Count]++;
                    toDistribute--;
                    counter++;
                }

                var x = histogram.Count;
                var blocksAsString = ListToString(blocks);
                histogram.Add(blocksAsString);
                if (x != histogram.Count)
                {
                    continue;
                }

                var index = 0;
                foreach (var b in histogram)
                {
                    if (b.Equals(blocksAsString))
                    {
                        return x - index;
                    }
                    index++;
                }
            }

            throw new Exception("Couldn't find a solution");
        }

        private string ListToString(List<int> blocks)
        {
            return blocks.Aggregate("", (current, block) => current + $" {block}");
        }
    }
}