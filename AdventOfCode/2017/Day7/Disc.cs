using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day7
{
    public class Disc
    {
        public string Name;
        public int Weight;
        public List<string> SubNames = new List<string>();

        public Disc(string program)
        {
            Weight = Convert.ToInt32(Regex.Match(program, @"([0-9])+").Value);
            Name = program.Substring(0, program.IndexOf(' '));

            if (!program.Contains("->"))
            {
                // Program doesn't have any sub programs.
                return;
            }

            SubNames.AddRange(program.Substring(program.IndexOf('>') + 2).Replace(" ", "").Split(',').ToList());
        }
    }
}