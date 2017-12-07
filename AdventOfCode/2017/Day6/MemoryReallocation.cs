using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day6
{
    public class MemoryReallocation
    {
        public int Part1(string input)
        {
            var matches = Regex.Matches(input, @"([0-9])+"); // match all digits
            var blocks = (from Match match in matches
                select Convert.ToInt32(match.Value)).ToList(); // convert from Matches to a List<int>

            var histogram =
                new HashSet<string>
                {
                    string.Join(" ", blocks)
                }; // if we try to add a duplicate, then histogram.Add() will return false, since a HashSet cannot contain duplicates.

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

                if (!histogram.Add(string.Join(" ", blocks)))
                {
                    return histogram.Count;
                }
            }
        }

        public int Part2(string input)
        {
            var matches = Regex.Matches(input, @"([0-9])+");
            var blocks = (from Match match in matches
                select Convert.ToInt32(match.Value)).ToList();

            var histogram =
                new HashSet<string>
                {
                    string.Join(" ", blocks)
                }; // if we try to add a duplicate, then histogram.Add() will return false, since a HashSet cannot contain duplicates.

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

                var blocksAsString = string.Join(" ", blocks);
                if (histogram.Add(blocksAsString))
                {
                    continue;
                }

                var index = 0;
                foreach (var b in histogram)
                {
                    if (b.Equals(blocksAsString))
                    {
                        return histogram.Count - index;
                    }
                    index++;
                }
            }
        }
    }
}