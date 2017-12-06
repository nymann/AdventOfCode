using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016.Day4
{
    public class SecurityThroughObscurity
    {
        #region Part 1

        public int Part1(List<string> input)
        {
            return (from line in input
                let encryptedName = line.Substring(0, line.LastIndexOf('-')).Replace("-", "")
                let sectorId =
                    Convert.ToInt32(
                        line.Substring(line.LastIndexOf('-') + 1,
                            line.IndexOf('[') - line.LastIndexOf('-') - 1))
                let checkSum = line.Substring(
                    line.IndexOf('[') + 1,
                    line.IndexOf(']') - line.IndexOf('[') - 1)
                where RoomIsReal(checkSum, encryptedName)
                select sectorId).Sum();
        }

        private bool RoomIsReal(string checksum, string encryptedName)
        {
            var calculatedChecksum =
                new string(
                    encryptedName.GroupBy(c => c)
                        .OrderByDescending(g => g.Count())
                        .ThenBy(g => g.Key)
                        .Take(5)
                        .Select(g => g.Key)
                        .ToArray());

            return checksum.Equals(calculatedChecksum);
        }

        #endregion

        #region Part 2
        public int Part2(List<string> input)
        {
            return (from line in input
                let encryptedName = line.Substring(0, line.LastIndexOf('-')).Replace("-", "")
                let sectorId =
                    Convert.ToInt32(line.Substring(line.LastIndexOf('-') + 1,
                        line.IndexOf('[') - line.LastIndexOf('-') - 1))
                where DecryptName(encryptedName, sectorId).Contains("north")
                select sectorId).Sum();
        }

        private string DecryptName(string encryptedName, int sectorId)
        {
            var decryptedName = "";
            for (var index = 0; index < encryptedName.ToLower().Length; index++)
            {
                var c = encryptedName.ToLower()[index];
                for (var i = 0; i < sectorId; i++)
                {
                    if (c == 'z')
                    {
                        c = 'a';
                        continue;
                    }

                    c++;
                }
                decryptedName += c;
            }

            return decryptedName;
        }
        #endregion
    }
}