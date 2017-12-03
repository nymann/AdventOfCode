using System;
using System.Linq;

namespace AdventOfCode._2017.Day1
{
    public class InverseCaptcha
    {
        public InverseCaptcha()
        {
            var input = new Helper.ReadFileLineByLine().FileAsString("C://Users//Nymann//Documents//AdventOfCode//AdventOfCode//2017//Day1//input.txt");
            //var input = "123425";
            var result = CalculateSumOfMatchingDigits(input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        // Part 1
        /*private int CalculateSumOfMatchingDigits(string input)
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
        }*/

        // Part 2
        private int CalculateSumOfMatchingDigits(string input)
        {
            var sum = 0;
            var halfwayArround = input.Length / 2;

            for (var index = 0; index < input.Length; index++)
            {
                var digit = input[index];
                var compareIndex = index + halfwayArround;

                // fx {1,2, 1 ,2}, and we are at index 2 (1).
                // halfwayArround = 4/2 = 2;
                // compareIndex = 2 + 2 = 4
                // We need to get to index 0.

                if (compareIndex >= input.Length)
                {
                    // How do we 'wrap' arround?
                    // Modulus!
                    // compareindex % input.length;
                    compareIndex %= input.Length;
                }

                if (digit.Equals(input[compareIndex]))
                {
                    sum += Convert.ToInt16(digit.ToString());
                }
            }

            return sum;
        }
    }
}