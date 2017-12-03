using System;
using System.Drawing;

namespace AdventOfCode._2017.Day3
{
    public class SpiralMemory
    {
        public SpiralMemory()
        {
            var input = 368078;
            //var input = 8;
            var arr = CreateSpiralPatternArray(input);
            var result = CalculateManhattanDistance(arr, input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        /* 5 4 3
         * 6 1 2 
         * 7 8 9
         * 
         * Length of the array / 2 is the starting point.
         * 9 / 2 = 4.5 = 4.
         * arr[4] = 1;
         * then increment array by 1.
         */

        /*private int[,] CreateArrayWithBorders(int dimensionSize)
        {
            // fill the borders with -1. (a unobtainable value).
            // dimenson is 3 (eg. 3 by 3 matrix)
            /*
             * -1 -1 -1 -1 -1
             * -1 00 00 00 -1
             * -1 00 00 00 -1
             * -1 00 00 00 -1
             * -1 -1 -1 -1 -1
             #1#

            // We do this so we don't have to handle edge cases (argumentOutOfRangeExceptions) later on.
            var arr = new int[dimensionSize + 2, dimensionSize + 2];
            var length = arr.GetLength(0); // it's a square so getLength(0) and getLength(1) is the same.
            for (var index = 0; index < length; index++)
            {
                arr[index, 0] = -1;
                arr[0, index] = -1;
                arr[index, length - 1] = -1;
                arr[length - 1, index] = -1;
            }

            return arr;
        }*/

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
            var finished = false;
            while (!finished)
            {
                if (number > input)
                {
                    break;
                }

                // Go right
                for (var i = 1; i <= travelDistance; i++)
                {
                    x++;
                    arr[x, y] = number;
                    if (number >= arr.Length)
                    {
                        finished = true;
                        break;
                    }
                    number++;
                }
                if (number > input)
                {
                    break;
                }

                // Go UP
                for (var i = 1; i <= travelDistance; i++)
                {
                    y--;
                    arr[x, y] = number;
                    number++;
                    if (number > arr.Length)
                    {
                        finished = true;
                        break;
                    }
                }
                if (number > input)
                {
                    break;
                }
                // increase travelDistance
                travelDistance++;

                // Go left
                for (var i = 1; i <= travelDistance; i++)
                {
                    x--;
                    arr[x, y] = number;
                    number++;
                    if (number > arr.Length)
                    {
                        finished = true;
                        break;
                    }
                }
                if (number > input)
                {
                    break;
                }

                // Go down
                for (var i = 1; i <= travelDistance; i++)
                {
                    y++;
                    arr[x, y] = number;
                    number++;
                    if (number > arr.Length)
                    {
                        finished = true;
                        break;
                    } 
                }

                // Increase travel distance
                travelDistance++;
            }

            return arr;
        }
            
        private int CalculateManhattanDistance(int[,] spiralArray, int input)
        {
            var manhattanDistance = -99;
            var centerSquare = new Point(spiralArray.GetLength(0)/2, spiralArray.GetLength(1) / 2);
            var inputSquare = new Point(0, 0);

            // Find the center
            for (int y = 0; y < spiralArray.GetLength(0); y++)
            {
                for (int x = 0; x < spiralArray.GetLength(1); x++)
                {
                    /*if (x == spiralArray.GetLength(1) -1)
                    {
                        Console.WriteLine(spiralArray[x, y]);
                    }

                    else
                    {
                        Console.Write($"{spiralArray[x, y]}\t");
                    }*/

                    if (spiralArray[x,y] == input)
                    {
                        inputSquare.X = x;
                        inputSquare.Y = y;
                        return Math.Abs(centerSquare.X - inputSquare.X) + Math.Abs(centerSquare.Y - inputSquare.Y);
                    }
                }
            }


            return manhattanDistance;
        }
    }
}