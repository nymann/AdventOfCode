using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day6
{
    public class ProbablyAFireHazard
    {
        public int Part1(List<string> input)
        {
            var grid = new bool[1000, 1000];

            foreach (var instruction in input)
            {
                var turnOn = false;
                var toggle = false;
                var s = instruction.Split(' ');
                var index = 0;
                if (s[index].Equals("toggle"))
                {
                    toggle = true;
                }
                else
                {
                    index++;
                    turnOn = s[index].Equals("on");
                }

                index++;
                var fromCoordinate = s[index].Split(',');
                var xFrom = Convert.ToInt32(fromCoordinate[0]);
                var yFrom = Convert.ToInt32(fromCoordinate[1]);

                index += 2;
                var toCoordinate = s[index].Split(',');
                var xTo = Convert.ToInt32(toCoordinate[0]);
                var yTo = Convert.ToInt32(toCoordinate[1]);

                grid = DoInstructionPart1(grid, xFrom, yFrom, xTo, yTo, toggle, turnOn);
            }

            return grid.Cast<bool>().Count(light => light);
        }

        public int Part2(List<string> input)
        {
            var grid = new int[1000, 1000];

            foreach (var instruction in input)
            {
                var turnOn = false;
                var toggle = false;
                var s = instruction.Split(' ');
                var index = 0;
                if (s[index].Equals("toggle"))
                {
                    toggle = true;
                }
                else
                {
                    index++;
                    turnOn = s[index].Equals("on");
                }

                index++;
                var fromCoordinate = s[index].Split(',');
                var xFrom = Convert.ToInt32(fromCoordinate[0]);
                var yFrom = Convert.ToInt32(fromCoordinate[1]);

                index += 2;
                var toCoordinate = s[index].Split(',');
                var xTo = Convert.ToInt32(toCoordinate[0]);
                var yTo = Convert.ToInt32(toCoordinate[1]);

                grid = DoInstructionPart2(grid, xFrom, yFrom, xTo, yTo, toggle, turnOn);
            }

            return grid.Cast<int>().Sum();
        }

        private bool[,] DoInstructionPart1(bool[,] grid, int xFrom, int yFrom, int xTo, int yTo,
            bool toggle, bool turnOn)
        {
            for (var x = xFrom; x <= xTo; x++)
            {
                for (var y = yFrom; y <= yTo; y++)
                {
                    if (toggle)
                    {
                        grid[x, y] = !grid[x, y];
                    }
                    else
                    {
                        grid[x, y] = turnOn;
                    }
                }
            }

            return grid;
        }

        private int[,] DoInstructionPart2(int[,] grid, int xFrom, int yFrom, int xTo, int yTo,
            bool toggle, bool turnOn)
        {
            for (var x = xFrom; x <= xTo; x++)
            {
                for (var y = yFrom; y <= yTo; y++)
                {
                    if (toggle)
                    {
                        grid[x, y] += 2;
                    }
                    else if (turnOn)
                    {
                        grid[x, y] += 1;
                    }
                    else
                    {
                        if (grid[x, y] == 0)
                        {
                            grid[x, y] = 0;
                        }
                        else
                        {
                            grid[x, y]--;
                        }
                    }
                }
            }

            return grid;
        }
    }
}