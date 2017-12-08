using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017.Day8
{
    public class HeardYouLikeRegisters
    {
        private readonly Dictionary<string, int> _registerValueLookup = new Dictionary<string, int>();

        public int Part1(List<string> input)
        {
            foreach (var instruction in input)
            {
                // example: "b inc 5 if a > 1",

                // check the condition first
                if (ConditionSatisfied(instruction))
                {
                    // do the operation
                    PerformOperation(instruction);
                }
            }

            var top = _registerValueLookup.OrderByDescending(x => x.Value).First();

            return top.Value;
        }

        public object Part2(List<string> input)
        {
            _registerValueLookup.Clear();

            var max = 0;
            
            foreach (var instruction in input)
            {
                // example: "b inc 5 if a > 1",

                // check the condition first
                var condition = ConditionSatisfied(instruction);
                if (!condition)
                {
                    continue;
                }

                // perform the operation and set the new max accordingly.
                max = Math.Max(max, PerformOperation(instruction));
            }

            return max;
        }


        private bool ConditionSatisfied(string instruction)
        {
            //  a > 1
            var temp = instruction.IndexOf(" if ") + 4;
            var condition = instruction.Substring(temp);
            var split = condition.Split(' ');

            if (!_registerValueLookup.ContainsKey(split[0]))
            {
                _registerValueLookup.Add(split[0], 0);
            }

            var var1 = _registerValueLookup[split[0]];

            var var2 = Convert.ToInt32(split[2]);
            var operand = split[1];

            switch (operand)
            {
                case ">":
                    return var1 > var2;

                case "<":
                    return var1 < var2;

                case "!=":
                    return var1 != var2;

                case "==":
                    return var1 == var2;

                case ">=":
                    return var1 >= var2;

                case "<=":
                    return var1 <= var2;
                default:
                    throw new Exception("ConditionSatisfied");
            }
        }

        private int PerformOperation(string instruction)
        {
            // fi dec 283 if tc > 1817
            var temp = instruction.IndexOf(" if ");
            var operation = instruction.Substring(0, temp);
            var split = operation.Split(' ').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (!_registerValueLookup.ContainsKey(split[0]))
            {
                _registerValueLookup.Add(split[0], 0);
            }

            var var2 = Convert.ToInt32(split[2]);
            if (split[1].Equals("inc"))
            {
                _registerValueLookup[split[0]] += var2;
            }
            else if (split[1].Equals("dec"))
            {
                _registerValueLookup[split[0]] -= var2;
            }
            else
            {
                throw new Exception("PerformOperation was neither inc or dec!");
            }

            return _registerValueLookup[split[0]];
        }
    }
}