using System;
using System.Drawing;

namespace AdventOfCode._2017.Day3
{
    public class SpiralMemory
    {
        private Point _inputPoint = new Point(0, 0);

        public SpiralMemory()
        {
            var input = 368078;
            //var input = 8;
            var arr = CreateSpiralPatternArray(input);
            var result = CalculateManhattanDistance(arr, input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        private int[,] CreateSpiralPatternArray(int input)
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
            
        private int CalculateManhattanDistance(int[,] spiralArray, int input)
        {
            var centerPoint = new Point(spiralArray.GetLength(0)/2, spiralArray.GetLength(1) / 2);

            if (_inputPoint.X == 0 && _inputPoint.Y == 0)
            {
                throw new Exception("Couldn't find an answer to the problem!");
            }

            return Math.Abs(centerPoint.X - _inputPoint.X) + Math.Abs(centerPoint.Y - _inputPoint.Y); 
        }
    }
}