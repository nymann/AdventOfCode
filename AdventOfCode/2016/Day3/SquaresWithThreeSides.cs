using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day3
{
    public class SquaresWithThreeSides
    {
        public int Part1(List<string> input)
        {
            var counter = 0;
            foreach (var line in input)
            {
                var matchCollection = Regex.Matches(line, "([0-9])+");
                for (var i = 0; i < matchCollection.Count - 2; i+=3)
                {
                    var a = Convert.ToInt32(matchCollection[i].Value);
                    var b = Convert.ToInt32(matchCollection[i + 1].Value);
                    var c = Convert.ToInt32(matchCollection[i + 2].Value);

                    if (ValidTriangle(a, b, c))
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public int Part2(List<string> input)
        {
            var counter = 0;
            var aList = new List<int>();
            var bList = new List<int>();
            var cList = new List<int>();

            foreach (var line in input)
            {
                var mc = Regex.Matches(line, "([0-9])+");
                aList.Add(Convert.ToInt32(mc[0].ToString()));
                bList.Add(Convert.ToInt32(mc[1].ToString()));
                cList.Add(Convert.ToInt32(mc[2].ToString()));
            }

            for (var i = 0; i < aList.Count - 2; i+=3)
            {
                var a = aList[i];
                var b = aList[i + 1];
                var c = aList[i + 2];
                
                if (ValidTriangle(a, b, c))
                {
                    counter++;
                }

                a = bList[i];
                b = bList[i + 1];
                c = bList[i + 2];

                if (ValidTriangle(a, b, c))
                {
                    counter++;
                }

                a = cList[i];
                b = cList[i + 1];
                c = cList[i + 2];

                if (ValidTriangle(a, b, c))
                {
                    counter++;
                }
            }
            
            return counter;
        }

        private bool ValidTriangle(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}