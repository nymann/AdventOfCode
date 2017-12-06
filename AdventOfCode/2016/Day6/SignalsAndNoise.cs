using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016.Day6
{
    public class SignalsAndNoise
    {
        public string Part1(List<string> input)
        {
            var solution = "";
            for (var i = 0; i < input[0].Length; i++)
            {
                var list = input.Select(line => line[i].ToString()).ToList();
                solution += list.GroupBy(x => x)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .First();
            }

            return solution;
        }

        public string Part2(List<string> input)
        {
            var solution = "";
            for (var i = 0; i < input[0].Length; i++)
            {
                var list = input.Select(line => line[i].ToString()).ToList();
                solution += list.GroupBy(x => x)
                    .OrderBy(g => g.Count())
                    .Select(g => g.Key)
                    .First();
            }

            return solution;
        }
    }
}