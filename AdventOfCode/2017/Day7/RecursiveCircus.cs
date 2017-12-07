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

            var bottomTower = BottomTower(programs);


            return bottomTower.Name;
        }

        public string Part2(List<string> input)
        {
            return "";
        }


        private Program BottomTower(IReadOnlyCollection<Program> programs)
        {
            var programsThatHaveSubPrograms = programs.Where(program => program.SubNames.Count > 0).Select(program => program.SubNames);
            var subProgramNames = new HashSet<string>();
            foreach (var programsThatHaveSubProgram in programsThatHaveSubPrograms)
            {
                foreach (var c in programsThatHaveSubProgram)
                {
                    subProgramNames.Add(c);
                }
            }

            var temp = programs.ToList();
            foreach (var program in temp)
            {
                if (subProgramNames.Contains(program.Name))
                {
                    temp.Remove(program);
                }
            }

            if (temp.Count != 1)
            {
                throw new Exception($"ERROR! Count {temp.Count}");
            }

            return temp.First();
        }
    }
}