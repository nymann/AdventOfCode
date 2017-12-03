using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    public class SignalsAndNoise
    {
        public SignalsAndNoise()
        {
            var input = new Helper.ReadFileLineByLine().FileAsStringList("C://Users//Nymann//Documents//day6.txt");

            var col0 = new List<char>();
            var col1 = new List<char>();
            var col2 = new List<char>();
            var col3 = new List<char>();
            var col4 = new List<char>();
            var col5 = new List<char>();
            var col6 = new List<char>();
            var col7 = new List<char>();


            foreach (var line in input)
            {
                for (var index = 0; index < line.Length; index++)
                {
                    var c = line[index];

                    switch (index)
                    {
                        case 0:
                            col0.Add(c);
                            break;
                        case 1:
                            col1.Add(c);
                            break;
                        case 2:
                            col2.Add(c);
                            break;
                        case 3:
                            col3.Add(c);
                            break;
                        case 4:
                            col4.Add(c);
                            break;
                        case 5:
                            col5.Add(c);
                            break;
                        case 6:
                            col6.Add(c);
                            break;
                        case 7:
                            col7.Add(c);
                            break;
                        default:
                            Console.WriteLine("Shouldn't happen!");
                            break;
                    }
                }
            }
            
            var leastOccuringCol0 = col0.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol1 = col1.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol2 = col2.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol3 = col3.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol4 = col4.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol5 = col5.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol6 = col6.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            var leastOccuringCol7 = col7.GroupBy(c => c).OrderBy(k => k.Count()).Select(k => k.Key).First();
            
            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}.", leastOccuringCol0, leastOccuringCol1, leastOccuringCol2, leastOccuringCol3, leastOccuringCol4, leastOccuringCol5, leastOccuringCol6, leastOccuringCol7);
            Console.ReadKey();
        }
    }
}