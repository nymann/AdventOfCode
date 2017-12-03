using System;
using System.Drawing;

namespace AdventOfCode._2017.Day3
{
    public class SpiralMemory
    {
        public SpiralMemory()
        {
            const int input = 368078;
            var result = SolutionForPartTwo(input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        private int SolutionForPartTwo(int input)
        {
            var number = 1;
            var dimensionSize = (int) Math.Ceiling(Math.Sqrt(input));
            
            // it's important that we have a center point.
            if (dimensionSize % 2 == 0)
            {
                dimensionSize++;
            }
            var arr = new int[dimensionSize, dimensionSize];

            // Start at the center
            var x = arr.GetLength(0) / 2;
            var y = arr.GetLength(1) / 2;
            var travelDistance = 1;

            arr[x, y] = number;

            while (true)
            {
                // The idea is that after each finished combo (right then up), (left then down) the size of the array expands, eg. why we increase the travel distance.
                // If this doesn't make sense, try to draw a spiral pattern from 1 to 26.

                // Go right
                for (var i = 1; i <= travelDistance; i++)
                {
                    x++;
                    if (x >= arr.GetLength(0))
                    {
                        goto EndThisMisery;
                    }
                    number = NumberToWrite(arr, new Point(x,y));
                    arr[x, y] = number;

                    if (number > input)
                    {
                        return number;
                    }
                }

                // Go UP
                for (var i = 1; i <= travelDistance; i++)
                {
                    y--;
                    if (y < 0)
                    {
                        goto EndThisMisery;
                    }

                    number = NumberToWrite(arr, new Point(x, y));
                    arr[x, y] = number;

                    if (number > input)
                    {
                        return number;
                    }
                }

                // increase travelDistance
                travelDistance++;

                // Go left
                for (var i = 1; i <= travelDistance; i++)
                {
                    x--;
                    if (x < 0)
                    {
                        goto EndThisMisery;
                    }

                    number = NumberToWrite(arr, new Point(x, y));
                    arr[x, y] = number;

                    if (number > input)
                    {
                        return number;
                    }
                }

                // Go down
                for (var i = 1; i <= travelDistance; i++)
                {
                    y++;
                    if (y >= arr.GetLength(1))
                    {
                        goto EndThisMisery;
                    }

                    number = NumberToWrite(arr, new Point(x, y));
                    arr[x, y] = number;

                    if (number > input)
                    {
                        return number;
                    }
                }

                // Increase travel distance
                travelDistance++;
            }
            EndThisMisery:

            throw new Exception($"Couldn't find a solution to the problem, last number was: {number}!");
        }

        private int NumberToWrite(int[,] arr, Point point)
        {
            // add the sum of the squares arround the 'point' square.
            var sum = 0;

            /*
             * [0,0] [1,0] [2,0]
             * [0,1] [1,1] [2,1]
             * [0,2] [1,2] [2,2]
             */

            // fx. we are at [0,0].
            // then sum = arr[1,0] + arr[1,1] + arr[0,1]
            
            for (var n = -1; n <= 1; n++)
            {
                var x = point.X + n;
                if (x < 0)
                {
                    continue;
                }

                if (x >= arr.GetLength(0))
                {
                    return sum;
                }

                for (var m = -1; m <= 1; m++)
                {
                    var y = point.Y + m;
                    if (y < 0 )
                    {
                        continue;
                    }

                    if (y >= arr.GetLength(1))
                    {
                        return sum;
                    }

                    sum += arr[x, y];
                }
            }

            return sum;
        }
    }
}