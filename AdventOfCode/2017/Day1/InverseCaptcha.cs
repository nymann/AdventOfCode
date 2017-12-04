using System;
using System.Linq;

namespace AdventOfCode._2017.Day1
{
    public class InverseCaptcha
    {
        public int Part1(string input)
        {
            var previousDigit = '0';
            var sum = 0;

            foreach (var digit in input)
            {
                if (digit.Equals(previousDigit))
                {
                    sum += Convert.ToInt16(digit.ToString());
                }

                previousDigit = digit;
            }

            if (input.Last().Equals(input.First()))
            {
                sum += Convert.ToInt16(input.First().ToString());
            }

            return sum;
        }

        public int Part2(string input)
        {
            var sum = 0;
            var halfwayArround = input.Length / 2;

            for (var index = 0; index < halfwayArround; index++)
            {
                var digit = input[index];
                var compareIndex = index + halfwayArround;

                // fx {1,2, 1 ,2}, and we are at index 2 (1).
                // halfwayArround = 4/2 = 2;
                // compareIndex = 2 + 2 = 4
                // We need to get to index 0.

                if (compareIndex >= input.Length)
                {
                    // So.. How do we 'wrap' arround?
                    // Modulus!
                    // compareindex % input.length; (4 % input.Length = 4 % 4 = 0, which was the index we wanted to go to)
                    compareIndex %= input.Length;
                }

                if (digit.Equals(input[compareIndex]))
                {
                    sum += Convert.ToInt16(digit.ToString()) * 2;
                }
            }

            return sum;
        }
    }
}