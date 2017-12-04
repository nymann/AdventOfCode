using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode._2015.Day1;
using AdventOfCode._2015.Day4;
using AdventOfCode._2015.Day5;
using AdventOfCode._2017.Day4;

namespace AdventOfCode
{
    class Program
    {
        public Program()
        {
            var swPart1 = new Stopwatch();
            var swPart2 = new Stopwatch();

            var input = new Helper.ReadFileLineByLine().FileAsStringList("C://Users//Nymann//Documents//AdventOfCode//AdventOfCode//2017//Day4//input.txt");

            var problem = new HighEntropyPassPhrases(); // Change this depending on what problem you want to solve.
            swPart1.Start();
            var part1Solution = problem.Part1(input);
            swPart1.Stop();
            swPart2.Start();
            var part2Solution = problem.Part2(input);
            swPart2.Stop();
            Console.WriteLine($"{problem.GetType().Name}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Part 1: {part1Solution}, in ({swPart1.ElapsedTicks} ticks, {swPart1.ElapsedMilliseconds} ms.)\n" +
                              $"Part 2: {part2Solution}, in ({swPart2.ElapsedTicks} ticks, {swPart2.ElapsedMilliseconds} ms.)");
            
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}