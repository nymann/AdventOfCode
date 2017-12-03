using System;
using System.Drawing;

namespace AdventOfCode._2017.Day3
{
    public class SpiralMemory
    {
        //private Point _inputPoint = new Point(0, 0);

        public SpiralMemory()
        {
            var input = 368078;
            //var input = 24;
            var result = SolutionForPartTwo(input);
            //var result = CalculateManhattanDistance(arr);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        // Part 1
        /*private int[,] CreateSpiralPatternArray(int input)
        {
            var number = 1;
            var dimensionSize = (int) Math.Ceiling(Math.Sqrt(input));
            var arr = new int[dimensionSize, dimensionSize];

            // Start at the center
            var x = arr.GetLength(0) / 2;
            var y = arr.GetLength(1) / 2;
            var travelDistance = 1;

            arr[x, y] = number;
            number++;

            while (true)
            {
                // Go right
                for (var i = 1; i <= travelDistance; i++)
                {
                    x++;
                    arr[x, y] = number;
                    if (number == input)
                    {
                        _inputPoint.X = x;
                        _inputPoint.Y = y;
                    }
                    if (number >= arr.Length)
                    {
                        goto EndThisMisery;
                    }

                    number++;
                }

                // Go UP
                for (var i = 1; i <= travelDistance; i++)
                {
                    y--;
                    arr[x, y] = number;
                    if (number == input)
                    {
                        _inputPoint.X = x;
                        _inputPoint.Y = y;
                    }

                    number++;
                    if (number > arr.Length)
                    {
                        goto EndThisMisery;
                    }
                }

                // increase travelDistance
                travelDistance++;

                // Go left
                for (var i = 1; i <= travelDistance; i++)
                {
                    x--;
                    arr[x, y] = number;
                    if (number == input)
                    {
                        _inputPoint.X = x;
                        _inputPoint.Y = y;
                    }
                    number++;
                    if (number > arr.Length)
                    {
                        goto EndThisMisery;
                    }
                }

                // Go down
                for (var i = 1; i <= travelDistance; i++)
                {
                    y++;
                    arr[x, y] = number;
                    if (number == input)
                    {
                        _inputPoint.X = x;
                        _inputPoint.Y = y;
                    }

                    number++;
                    if (number > arr.Length)
                    {
                        goto EndThisMisery;
                    } 
                }

                // Increase travel distance
                travelDistance++;
            }
            EndThisMisery:

            return arr;
        }
            
        private int CalculateManhattanDistance(int[,] spiralArray)
        {
            var centerPoint = new Point(spiralArray.GetLength(0)/2, spiralArray.GetLength(1) / 2);

            if (_inputPoint.X == 0 && _inputPoint.Y == 0)
            {
                throw new Exception("Couldn't find an answer to the problem!");
            }

            return Math.Abs(centerPoint.X - _inputPoint.X) + Math.Abs(centerPoint.Y - _inputPoint.Y); 
        }*/

        private int SolutionForPartTwo(int input)
        {
            var number = 1;
            var dimensionSize = (int) Math.Ceiling(Math.Sqrt(input));
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

            var sum = 0;

            /*
             * [0,0] [1,0] [2,0]
             * [0,1] [1,1] [2,1]
             * [0,2] [1,2] [2,2]
             */

            // fx. we are at 1,1

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