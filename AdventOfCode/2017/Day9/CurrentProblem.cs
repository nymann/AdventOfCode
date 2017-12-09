using System.Collections.Generic;

namespace AdventOfCode._2017.Day9
{
    public class CurrentProblem
    {
        public object Part1(List<string> input)
        {
            var sumOfGroups = 0;
            var insideGarbage = false;
            var result = 0;

            foreach (var line in input)
            {
                for (var index = 0; index < line.Length; index++)
                {
                    var c = line[index];
                    if (c.Equals('<') && !insideGarbage)
                    {
                        insideGarbage = true;
                        continue;
                    }

                    if (insideGarbage)
                    {
                        switch (c)
                        {
                            case '!':
                                index++;
                                continue;
                            case '>':
                                insideGarbage = false;
                               continue;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (c)
                        {
                            case '{':
                                sumOfGroups++;
                                break;
                            case '}':
                                result += sumOfGroups;
                                sumOfGroups--;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return result;
        }

        public object Part2(List<string> input)
        {
            var sumOfGroups = 0;
            var insideGarbage = false;
            var sumOfGarbage = 0;

            foreach (var line in input)
            {
                for (var index = 0; index < line.Length; index++)
                {
                    var c = line[index];
                    if (c.Equals('<') && !insideGarbage)
                    {
                        insideGarbage = true;
                        continue;
                    }

                    if (!insideGarbage)
                    {
                        continue;
                    }


                    switch (c)
                    {
                        case '!':
                            index++;
                            continue;
                        case '>':
                            insideGarbage = false;
                            continue;
                        default:
                            break;
                    }
                    sumOfGarbage++;
                }
            }

            return sumOfGarbage;
        }
    }



}