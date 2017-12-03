using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day2
{
    public class CorruptionChecksum
    {
        public CorruptionChecksum()
        {
            var input = new Helper.ReadFileLineByLine().FileAsStringList("C://Users//Nymann//Documents//AdventOfCode//AdventOfCode//2017//Day2//input.txt");
            var result = CalculateSpreadsheetChecksum(input);
            Console.WriteLine($"The answer to {GetType().Name} is: {result}.");
            Console.ReadKey();
        }

        private int CalculateSpreadsheetChecksum(IEnumerable<string> input)
        {
            var sum = 0;
            foreach (var collumn in input)
            {
                var intArr = Array.ConvertAll(collumn.Split('\t'), int.Parse);
                sum += intArr.Max() - intArr.Min();
            }
            
            return sum;
        }
    }
}