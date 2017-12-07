using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day7
{
    public class Disc
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> ChildNames { get; set; }
        public List<Disc> ChildDiscs { get; set; }
        public Disc Parent { get; set; }

        public Disc(string program)
        {
            Weight = Convert.ToInt32(Regex.Match(program, @"([0-9])+").Value);
            Name = program.Substring(0, program.IndexOf(' '));

            ChildNames = new List<string>();

            if (program.Contains("->"))
            {
                ChildNames.AddRange(program.Substring(program.IndexOf('>') + 2).Replace(" ", "").Split(',').ToList());
            }           
        }

        public void AddChildDiscs(IEnumerable<Disc> discs)
        {
            // ChildDiscs = ChildNames.Select(x => discs.First(y => y.Name == x)).ToList();
            ChildDiscs = discs.Where(d => ChildNames.Any(c => c.Equals(d.Name))).ToList();
            

            ChildDiscs.ForEach(x => x.Parent = this);

            // same as.
            /*foreach (var childDisc in ChildDiscs)
            {
                childDisc.Parent = this;
            }*/
        }

        public int GetTotalWeight()
        {
            var childSum = ChildDiscs.Sum(x => x.GetTotalWeight());
            return childSum + Weight;
        }

        public bool IsBalanced()
        {
            // if it's balanced we will only have one group.
            var groups = ChildDiscs.GroupBy(x => x.GetTotalWeight());
            return groups.Count() == 1;
        }

        public (Disc disc, int targetWeight) GetUnbalancedChild()
        {
            var groups = ChildDiscs.GroupBy(x => x.GetTotalWeight());
            var targetWeight = groups.First(x => x.Count() > 1).Key; // there's only one wrong weight, so we can take the first.
            var unbalancedChild = groups.First(x => x.Count() == 1).First();

            return (unbalancedChild, targetWeight);
        }
    }
}