using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day2
{
    public class WasToldThereWouldBeNoMath
    {
        public int Part1(IEnumerable<string> input)
        {
            return input.Select(line => Array.ConvertAll(line.Split('x'), int.Parse)).Select(boxDimensions =>
                2 * boxDimensions[0] * boxDimensions[1] + // 2lw +
                2 * boxDimensions[1] * boxDimensions[2] + // 2wh +
                2 * boxDimensions[0] * boxDimensions[2] + // 2lh +
                AreaOfSmallestSide(boxDimensions)).Sum(); // areaOfSmallestSide
        }

        public int Part2(IEnumerable<string> input)
        {
            return input.Select(line => Array.ConvertAll(line.Split('x'), int.Parse)).Select(boxDimensions =>
                boxDimensions[0] * boxDimensions[1] * boxDimensions[2] + // Bow
                RibbonWrap(boxDimensions)).Sum(); // Wrap
        }

        private int AreaOfSmallestSide(int[] dimensionsOfBox)
        {
            var arr = dimensionsOfBox;
            Array.Sort(arr);
            return arr[0] * arr[1];
        }

        private int RibbonWrap(int[] dimensionsOfBox)
        {
            var arr = dimensionsOfBox;
            Array.Sort(arr);
            return arr[0] * 2 + arr[1] * 2;
        }
    }
}