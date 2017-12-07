using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day7
{
    public class RecursiveCircus
    {
        private readonly List<Disc> _programs = new List<Disc>();

        public string Part1(List<string> input)
        {
            var programs = input.Select(program => new Disc(program)).ToList();
            return BottomTower(programs);
        }

        public string Part2(List<string> input)
        {
            _programs.AddRange(input.Select(program => new Disc(program)).ToList());
            var bottomTower = BottomTower(_programs);
            var bottomProgram = _programs.First(p => p.Name.Equals(bottomTower));

            // find the bottom-tower's sub programs.
            var bottomSubPrograms = _programs.Where(program => bottomProgram.SubNames.Contains(program.Name)).ToList();


            // add those to n new lists.
            var weights = new int[bottomSubPrograms.Count];

            // calculate the sum of each.
            var s = "";
            for (var index = 0; index < bottomSubPrograms.Count; index++)
            {
                var bottomSubProgram = bottomSubPrograms[index];
                weights[index] = Weight(bottomSubProgram);
                s += " " + weights[index];
            }

            return s;
        }

        private string BottomTower(List<Disc> programs)
        {
            var names = programs.Select(program => program.Name).ToList();
            foreach (var name in names)
            {
                if (!programs.Any(program => program.SubNames.Contains(name)))
                {
                    return name;
                }
            }

            throw new Exception("Couldn't find a solution for BottomTower().");
        }

        private int Weight(Disc program)
        {
            var cP = program;
            var weight = cP.Weight;
            while (cP.SubNames.Count > 0)
            {
                foreach (var t in cP.SubNames)
                {
                    cP = _programs.First(x => x.Name.Equals(t));
                    weight += cP.Weight;
                }
            }
            return weight;
        }
    }
}