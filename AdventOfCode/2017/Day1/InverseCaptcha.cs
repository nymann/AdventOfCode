using System;
using System.Linq;

namespace AdventOfCode._2017.Day1
{
    public class InverseCaptcha
    {
        public InverseCaptcha()
        {
            var input = new Helper.ReadFileLineByLine().FileAsString("C://Users//Nymann//Documents//AdventOfCode//AdventOfCode//2017//Day1//input.txt");
            var result = CalculateSumOfMatchingDigits(input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        private int CalculateSumOfMatchingDigits(string input)
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
    }
}