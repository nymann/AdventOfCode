using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class NoTimeForATaxiCab
    {
        private readonly string input = "R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";
        
        //private string input = "R8, R4, R4, R8";
        private Point _coord;
        private int _direction = 0; // North = 0, East = 1, South = 2, West = 3.
        private List<Point> coordsVisited;

        public NoTimeForATaxiCab()
        {
            input = input.Trim();
            var inputArr = input.Split(',');
            coordsVisited = new List<Point>();

            foreach (var command in inputArr)
            {
                var cmd = command.Trim();

                var turnDirection = cmd[0];
                Direction(turnDirection);
                cmd = cmd.Substring(1, cmd.Length - 1);
                var steps = int.Parse(cmd);
                Move(steps);
            }

            //Console.WriteLine(Math.Abs(_coord.X) + Math.Abs(_coord.Y));
            for (int i = 0; i < coordsVisited.Count; i++)
            {
                for (int j = 0; j < coordsVisited.Count; j++)
                {
                    if (i != j && coordsVisited[i].X == coordsVisited[j].X && coordsVisited[i].Y == coordsVisited[j].Y)
                    {
                        Console.WriteLine("Duplicate found at {0},{1} which is {2} away!", coordsVisited[i].X, coordsVisited[i].Y, Math.Abs(coordsVisited[i].X) + Math.Abs(coordsVisited[i].Y));
                    }
                    
                }
            }

            Console.ReadLine();
        }

        private void Direction(char turnDirection)
        {
            switch (turnDirection)
            {
                case 'L':
                    if (_direction == 0)
                    {
                        _direction = 3;
                    }
                    else
                    {
                        _direction--;
                    }
                    break;
                case 'R':
                    if (_direction == 3)
                    {
                        _direction = 0;
                    }
                    else
                    {
                        _direction++;
                    }
                    break;
                default:
                    Console.WriteLine("ERROR! turnDirection was '{0}'.", turnDirection);
                    break;
            }
        }

        private void Move(int steps)
        {
            switch (_direction)
            {
                case 0: //North
                    for (var i = 0; i < steps; i++)
                    {
                        _coord.Y ++;
                        coordsVisited.Add(new Point(_coord.X, _coord.Y));
                    }
                    
                    break;

                case 1: // East
                    for (var i = 0; i < steps; i++)
                    {
                        _coord.X++;
                        coordsVisited.Add(new Point(_coord.X, _coord.Y));
                    }
                    break;

                case 2: // South
                    for (var i = 0; i < steps; i++)
                    {
                        _coord.Y --;
                        coordsVisited.Add(new Point(_coord.X, _coord.Y));
                    }
                    break;

                case 3: // West
                    for (var i = 0; i < steps; i++)
                    {
                        _coord.X--;
                        coordsVisited.Add(new Point(_coord.X, _coord.Y));
                    }
                    break;

                default:
                    Console.WriteLine("You fucked up.");
                    break;
            }
            
        }
    }
    
}