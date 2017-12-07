using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day7
{
    public class RecursiveCircus
    {
        public string Part1(List<string> input)
        {
            var programs = input.Select(program => new Program(program)).ToList();
            



            return programs.First().Name;
        }

        public string Part2(List<string> input)
        {
            return "";
        }


        private bool TowerBuild(IReadOnlyCollection<Program> programs)
        {
            var ammountOfPrograms = programs.Count;
            var programsUsed = 0;
            var programsThatContainsSubPrograms = programs.Count(program => program.SubNames.Count > 0);

            foreach (var program in programs)
            {
                if (programsUsed < )
                {
                    
                }

                return ammountOfPrograms == programsUsed;
            }

            return false;
        }
    }
}