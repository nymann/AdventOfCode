using System;

namespace AdventOfCode._2015.Day1
{
    public class NotQuiteLisp
    {
        public int Part1(string input)
        {
            var floor = 0;

            foreach (var c in input)
            {
                switch (c)
                {
                    case '(':
                        // UP
                        floor++;
                        break;
                    case ')':
                        // DOWN
                        floor--;
                        break;
                    default:
                        throw new Exception($"Input is not a valid floor changing operation! Input was: '{c}'!");
                }
            }

            return floor;
        }

        public int Part2(string input)
        {
            var floor = 0;
            var index = 0;
            foreach (var c in input)
            {
                switch (c)
                {
                    case '(':
                        // UP
                        floor++;
                        break;
                    case ')':
                        // DOWN
                        floor--;
                        break;
                    default:
                        throw new Exception($"Input is not a valid floor changing operation! Input was: '{c}'!");
                }
                index++;

                if (floor == -1)
                {
                    return index;
                }
                
            }

            throw new Exception("Couldn't find a solution to the problem!");
        }
    }
}