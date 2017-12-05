using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day7
{
    public class SomeAssemblyRequired
    {
        public Dictionary<string, ushort> Dictionary;


        public ushort Part1(List<string> input, string wire)
        {
            Dictionary = new Dictionary<string, ushort>();
            Part1Calculations(input);

            return Dictionary[wire];
        }

        public Dictionary<string, ushort> Part1Calculations(List<string> input)
        {
            foreach (var instruction in input)
            {
                var instructionArr = instruction.Split();

                #region NOT
                if (instruction.Contains("NOT"))
                {
                    if (!Dictionary.ContainsKey(instructionArr[1]))
                    {
                        continue;
                    }

                    if (!Dictionary.ContainsKey(instructionArr[3]))
                    {
                        Dictionary.Add(instructionArr[3], 0);
                    }

                    var value = Dictionary[instructionArr[1]];
                    value = (ushort) ~value;

                    var signalNames = instructionArr.Last().Split();

                    foreach (var name in signalNames)
                    {
                        if (!Dictionary.ContainsKey(name))
                        {
                            Dictionary.Add(name, 0);
                        }

                        Dictionary[name] = (ushort)value;
                    }
                    Dictionary[instructionArr.Last()] = value;

                }
                #endregion

                #region AND

                else if (instruction.Contains("AND"))
                {
                    var a = ObtainNumber(instructionArr, 0);
                    var b = ObtainNumber(instructionArr, 2);

                    if (a == null || b == null)
                    {
                        continue;
                    }

                    Dictionary[instructionArr.Last()] = (ushort)(a & b);
                }

                #endregion

                #region OR

                else if (instruction.Contains("OR"))
                {
                    var a = ObtainNumber(instructionArr, 0);
                    var b = ObtainNumber(instructionArr, 2);

                    if (a == null || b == null)
                    {
                        continue;
                    }

                    Dictionary[instructionArr.Last()] = (ushort)(a | b);
                }

                #endregion

                #region RSHIFT

                else if (instruction.Contains("RSHIFT"))
                {
                    var a = ObtainNumber(instructionArr, 0);
                    var b = ObtainNumber(instructionArr, 2);

                    if (a == null || b == null)
                    {
                        continue;
                    }

                    Dictionary[instructionArr.Last()] = (ushort)(a >> b);
                }

                #endregion

                #region LSHIFT

                else if (instruction.Contains("LSHIFT"))
                {
                    var a = ObtainNumber(instructionArr, 0);
                    var b = ObtainNumber(instructionArr, 2);

                    if (a == null || b == null)
                    {
                        continue;
                    }

                    Dictionary[instructionArr.Last()] = (ushort)(a << b);
                }

                #endregion

                // done (I think)
                #region ASSIGN VALUE

                else
                {
                    var value = ObtainNumber(instructionArr, 0);

                    if (value == null)
                    {
                        continue;
                    }

                    var signalNames = instructionArr.Last().Split();

                    foreach (var name in signalNames)
                    {
                        if (!Dictionary.ContainsKey(name))
                        {
                            Dictionary.Add(name, 0);
                        }

                        Dictionary[name] = (ushort) value;
                    }
                }

                #endregion
            }

            return Dictionary;
        }

        private ushort? ObtainNumber(IReadOnlyList<string> instructionArr, int index)
        {
            ushort a;
            var regex = new Regex(@"\d+");
            var match = regex.Match(instructionArr[index]);
            if (match.Success)
            {
                // if it's a digit.
                a = Convert.ToUInt16(match.Value);
            }
            else
            {
                if (!Dictionary.ContainsKey(instructionArr[index]))
                {
                    return null;
                }

                a = Dictionary[instructionArr[index]];
            }

            return a;
        }

        public int Part2(List<string> input)
        {
            return 0;
        }
    }
}