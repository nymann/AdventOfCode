using System;
using System.Collections.Generic;

namespace AdventOfCode._2017.Day5
{
    public class CurrentProblem
    {
        public int Part1(List<string> input)
        {
            var integers = input.ConvertAll(Convert.ToInt32);
            var steps = 0;
            var index = 0;

            while (index < integers.Count)
            {
                var temp = index;
                index += integers[index];
                integers[temp]++;
                steps++;
            }
            return steps;
        }

        public int Part2(List<string> input)
        {
            var integers = input.ConvertAll(Convert.ToInt32);
            var steps = 0;
            var index = 0;

            while (index < integers.Count)
            {
                var temp = index;
                index += integers[index];
                if (index - temp >= 3)
                {
                    integers[temp]--;
                }
                else
                {
                    integers[temp]++;
                }

                steps++;
            }
            return steps;
        }
    }
}