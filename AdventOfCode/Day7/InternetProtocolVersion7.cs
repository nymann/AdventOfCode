using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class InternetProtocolVersion7
    {

        public InternetProtocolVersion7()
        {
            //var input = new Helper.ReadFileLineByLine().ReadFile("C://Users//Nymann//Documents//day7.txt");
            string[] input =
            {
                "abba[mnop]qrst",
                "abcd[bddb]xyyx",
                "aaaa[qwer]tyui",
                "ioxxoj[asdfgh]zxcvbn"
            };

            List<string> supportsTLS = new List<string>();

            foreach (var line in input)
            {
                bool insideBrackets = false;
                bool doesLineContainPalindrone = false;

                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == '[')
                    {
                        insideBrackets = !insideBrackets;
                        string insideBrack = line.Substring(i + 1, line.IndexOf(']') - (i+1));
                        if (insideBrack.Length == 4 && DoesLineContainPalindrone(insideBrack))
                        {
                            break;
                        }
                        
                    }

                    else if (!doesLineContainPalindrone && !insideBrackets)
                    {
                        doesLineContainPalindrone = Next4CharsPalindrone(line, i);
                    }
                }
            }

            foreach (var line in supportsTLS)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }

        private bool Next4CharsPalindrone(string line, int startIndex)
        {
            var temp = startIndex;

            if (line.Length - 1 < startIndex + 3)
            {
                return false;
            }

            var endIndex = startIndex + 3;

            while (endIndex > startIndex)
            {
                if (line[endIndex] != line[startIndex])
                {
                    return false;
                }

                endIndex--;
                startIndex++;
            }
            if (line.Substring(temp, 4).Distinct().Count() == 1)
            {
                return false;
            }
            return true;
        }

        private bool DoesLineContainPalindrone(string line)
        {
            int startIndex = 0;
            int endIndex = startIndex + 3;


            while (endIndex > startIndex)
            {
                if (line[endIndex] != line[startIndex])
                {
                    return false;
                }

                endIndex--;
                startIndex++;
            }

            return true;
        }
    }
}