using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.DayThree
{
    public class SquaresWithThreeSides
    {
        private readonly List<int> _a = new List<int>();
        private readonly List<int> _b = new List<int>();
        private readonly List<int> _c = new List<int>();
        

        public SquaresWithThreeSides()
        {
            var input = new Helper.ReadFileLineByLine().ReadFile("C://Users//Nymann//Documents//day3.txt");

            for (var i = 0; i < input.Count; i++)
            {
                var l = input[i].TrimStart();
                var k1 = int.Parse(l.Substring(0, l.IndexOf(' ')));
                l = l.Substring(l.IndexOf(' '));
                l = l.TrimStart();
                var k2 = int.Parse(l.Substring(0, l.IndexOf(' ')));
                l = l.Substring(l.IndexOf(' '));
                l = l.TrimStart();
                var k3 = int.Parse(l);

                switch (i % 3)
                {
                    case 0:
                        _a.Add(k1);
                        _a.Add(k2);
                        _a.Add(k3);
                        break;
                    case 1:
                        _b.Add(k1);
                        _b.Add(k2);
                        _b.Add(k3);
                        break;
                    case 2:
                        _c.Add(k1);
                        _c.Add(k2);
                        _c.Add(k3);
                        break;
                    default:
                        Console.WriteLine(@"This should never happen.");
                        break;
                }
            }

            var counterOfValidTriangles = _a.Where((t, i) => IsTrianglePossible(t, _b[i], _c[i])).Count();

            Console.WriteLine(counterOfValidTriangles);
            Console.ReadKey();
        }

        private bool IsTrianglePossible(int a, int b, int c)
        {
            return (a + b) > c && (a + c) > b && (b + c) > a;
        }
    }
}