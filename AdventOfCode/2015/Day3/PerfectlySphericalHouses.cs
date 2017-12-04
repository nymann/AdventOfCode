using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode._2015.Day3
{
    public class PerfectlySphericalHouses
    {
        public int Part1(string input)
        {
            // Idea 1 list of points
            var x = 0;
            var y = 0;
            var visitedPoints = new Dictionary<int, List<int>> {{x, new List<int> {y}}};
            var giftsDelivered = 1;
            foreach (var move in input)
            {
                switch (move)
                {
                    case '<':
                        x--;
                        break;

                    case '>':
                        x++;
                        break;

                    case 'v':
                        y--;
                        break;

                    case '^':
                        y++;
                        break;
                    default:
                        throw new Exception($"'{move}' is not supported");
                }

                if (visitedPoints.ContainsKey(x) && visitedPoints[x].Contains(y))
                {
                    continue;
                }

                if (!visitedPoints.ContainsKey(x))
                {
                    visitedPoints.Add(x, new List<int>());
                }

                visitedPoints[x].Add(y);
                giftsDelivered++;
            }

            return giftsDelivered;
        }

        public int Part2(string input)
        {
            var santaInstructions = "";
            var roboSantaInstructions = "";
            var roboSanta = false;
            foreach (var instruction in input)
            {
                if (roboSanta)
                {
                    roboSantaInstructions += instruction;
                }
                else
                {
                    santaInstructions += instruction;
                }
                roboSanta = !roboSanta;
            }

            var roboSantaVisitedPoints = PerformInstructions(roboSantaInstructions);
            var santaVisitedPoints = PerformInstructions(santaInstructions, roboSantaVisitedPoints);

            return santaVisitedPoints.Sum(globalVisitedPoints => globalVisitedPoints.Value.Count);
        }

        private Dictionary<int, List<int>> PerformInstructions(IEnumerable<char> instructions, Dictionary<int, List<int>> visitedPoints = null)
        {
            var x = 0;
            var y = 0;
            if (visitedPoints == null)
            {
                visitedPoints = new Dictionary<int, List<int>> { { x, new List<int> { y } } };
            }

            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case '<':
                        x--;
                        break;

                    case '>':
                        x++;
                        break;

                    case 'v':
                        y--;
                        break;

                    case '^':
                        y++;
                        break;
                    default:
                        throw new Exception($"'{instruction}' is not supported");
                }

                if (visitedPoints.ContainsKey(x) && visitedPoints[x].Contains(y))
                {
                    continue;
                }

                if (!visitedPoints.ContainsKey(x))
                {
                    visitedPoints.Add(x, new List<int>());
                }

                visitedPoints[x].Add(y);
            }

            return visitedPoints;
        }
    }
}