using System;
using System.Collections.Generic;

namespace AdventOfCode._2016.Day2
{
    public class BathroomSecurity
    {
        public string Part1(List<string> input)
        {
            char[] board =
            {
                ' ', ' ', ' ', ' ', ' ',
                ' ', '1', '2', '3', ' ',
                ' ', '4', '5', '6', ' ',
                ' ', '7', '8', '9', ' ',
                ' ', ' ', ' ', ' ', ' '
            };

            var code = "";
            var position = 12; // index 12 in the array gives the keycode 5

            foreach (var line in input)
            {
                foreach (var instruction in line)
                {
                    var newPosition = Move(ConvertInstructionPart1(instruction), board, position);
                    if (newPosition == null)
                    {
                        continue;
                    }
                    position = (int) newPosition;
                }
                code += board[position];
            }

            return code;
        }

        public string Part2(List<string> input)
        {
            char[] board =
            {
                ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '1', ' ', ' ', ' ',
                ' ', ' ', '2', '3', '4', ' ', ' ',
                ' ', '5', '6', '7', '8', '9', ' ',
                ' ', ' ', 'A', 'B', 'C', ' ', ' ',
                ' ', ' ', ' ', 'D', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' '
            };

            var code = "";
            var position = 22; // index 22 in the array gives the keycode 5

            foreach (var line in input)
            {
                foreach (var instruction in line)
                {
                    var newPosition = Move(ConvertInstructionPart2(instruction), board, position);
                    if (newPosition == null)
                    {
                        continue;
                    }
                    position = (int) newPosition;
                }
                code += board[position];
            }

            return code;
        }

        private int ConvertInstructionPart1(char instruction)
        {
            switch (instruction)
            {
                case 'U':
                    return -5; // We are using an array with a border, hence not the -3 but -7.

                case 'D':
                    return 5; // We are using an array with a border, hence not the 3 but 7.

                case 'L':
                    return -1;

                case 'R':
                    return 1;

                default:
                    throw new Exception("ERROR!");
            }
        }

        private int ConvertInstructionPart2(char instruction)
        {
            switch (instruction)
            {
                case 'U':
                    return -7; // We are using an array with a border, hence not the -3 but -7.

                case 'D':
                    return 7; // We are using an array with a border, hence not the 3 but 7.

                case 'L':
                    return -1;

                case 'R':
                    return 1;

                default:
                    throw new Exception("ERROR!");
            }
        }

        private int? Move(int instruction, IReadOnlyList<char> board, int position)
        {
            if (board[position + instruction] == ' ')
            {
                return null;
            }

            return position + instruction;
        }
    }
}