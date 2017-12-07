using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017.Day7
{
    public class RecursiveCircus
    {
        public string Part1(List<string> input)
        {
            var programs = input.Select(program => new Disc(program)).ToList();
            return NameOfRootProgram(programs);
        }

        public string Part2(List<string> input)
        {
            var discs = input.Select(d => new Disc(d)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs)); // Add the children discs.
            var disc = GetBaseDisc(discs);

            var desiredWeight = 0;

            while (!disc.IsBalanced())
            {
                (disc, desiredWeight) = disc.GetUnbalancedChild();
            }

            var weightDelta = desiredWeight - disc.GetTotalWeight();
            return (disc.Weight + weightDelta).ToString();
        }

        public static Disc GetBaseDisc(IEnumerable<Disc> discs)
        {
            var disc = discs.First();

            while (disc.Parent != null)
            {
                disc = disc.Parent;
            }

            return disc;
        }

        private string NameOfRootProgram(List<Disc> discs)
        {
            var names = discs.Select(program => program.Name).ToList();
            foreach (var name in names)
            {
                if (!discs.Any(program => program.ChildNames.Contains(name)))
                {
                    return name;
                }
            }

            throw new Exception("Couldn't find a solution for NameOfRootProgram().");
        }
    }
}