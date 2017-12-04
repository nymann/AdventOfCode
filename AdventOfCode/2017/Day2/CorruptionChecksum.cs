using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day2
{
    public class CorruptionChecksum
    {

        // Part 1
        public int Part1(IEnumerable<string> input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var intArr = Array.ConvertAll(line.Split('\t'), int.Parse);
                sum += intArr.Max() - intArr.Min();
            }
            
            return sum;
        }

        // Part 2
        public int Part2(IEnumerable<string> input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var intArr = Array.ConvertAll(line.Split('\t'), int.Parse);
                
                for (var i = 0; i < intArr.Length; i++)
                {
                    for (var j = 0; j < intArr.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (intArr[i] % intArr[j] == 0)
                        {
                            sum += intArr[i] / intArr[j];
                        }
                    }
                }
            }

            return sum;
        }
    }
}