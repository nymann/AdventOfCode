using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode._2016.Day1
{
    public class NoTimeForATaxiCab
    {
        private readonly List<Point> _visitedPoints = new List<Point>();
        private PositionDirection _positionDirection = new PositionDirection();

        public int Part1(string input)
        {
            var arr = input.Replace(",", "").Split(' ');

            _positionDirection = new PositionDirection();

            foreach (var instruction in arr)
            {
                Rotate(instruction[0].Equals('R'));
                Move(Convert.ToInt32(instruction.Substring(1)));
            }

            return Math.Abs(_positionDirection.Position.X) + Math.Abs(_positionDirection.Position.Y);
        }

        public int Part2(string input)
        {
            var arr = input.Replace(",", "").Split(' ');

            foreach (var instruction in arr)
            {
                Rotate(instruction[0].Equals('R'));
                Move(Convert.ToInt32(instruction.Substring(1)));

                
                if (_visitedPoints.Count == _visitedPoints.Distinct().Count())
                {
                    continue;
                }

                // If list contains a duplicate.
                var hash = new HashSet<Point>();
                var duplicate = _visitedPoints.Where(i => !hash.Add(i)).ToList().First();
                return Math.Abs(duplicate.X) + Math.Abs(duplicate.Y);
            }

            return Math.Abs(_positionDirection.Position.X) + Math.Abs(_positionDirection.Position.Y);
        }

        private void Change(bool x, bool increment, int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                if (x)
                {
                    if (increment)
                    {
                        _positionDirection.Position.X++;
                    }
                    else
                    {
                        _positionDirection.Position.X--;
                    }
                }
                else
                {
                    if (increment)
                    {
                        _positionDirection.Position.Y++;
                    }
                    else
                    {
                        _positionDirection.Position.Y--;
                    }
                }

                _visitedPoints.Add(new Point(_positionDirection.Position.X, _positionDirection.Position.Y));
            }
        }

        private void Move(int distance)
        {
            switch (_positionDirection.Direction)
            {
                case Direction.N:
                    Change(false, true, distance);
                    break;
                case Direction.E:
                    Change(true, true, distance);
                    break;
                case Direction.S:
                    Change(false, false, distance);
                    break;
                case Direction.W:
                    Change(true, false, distance);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Rotate(bool turnRight)
        {
            if (turnRight)
            {
                _positionDirection.Direction++;
            }
            else
            {
                _positionDirection.Direction--;
            }

            _positionDirection.Direction &= (Direction) 3;
        }


    }
}