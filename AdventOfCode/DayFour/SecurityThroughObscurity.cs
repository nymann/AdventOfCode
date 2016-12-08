using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayFour
{
    public class SecurityThroughObscurity
    {
        public SecurityThroughObscurity()
        {
            //var input = new Helper.ReadFileLineByLine().ReadFile("C://Users//Nymann//Documents//day4.txt");
            string[] input =
            {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "a-b-c-d-e-f-g-h-987[abcde]"
            };

            foreach (var room in input)
            {
                string encryptedName = room.Substring(0, room.IndexOf('['));
                string checksum = room.Substring(room.IndexOf('[') + 1);
                checksum = checksum.Substring(0, checksum.IndexOf(']'));
                Console.WriteLine(encryptedName);
                if (IsRoomReal(encryptedName, checksum))
                {
                    Console.WriteLine("{0}, is real!", room);
                }
            }

            Console.ReadKey();

        }

        private bool IsRoomReal(string encryptedName, string checksum)
        {
            //encryptedName = encryptedName.Replace("-", string.Empty);
            encryptedName = Regex.Replace(encryptedName, @"[\d-]", string.Empty);

            var l = new Dictionary<char, int>();
            Console.WriteLine("\n\n\t{0}", checksum);
            foreach (char c in encryptedName)
            {
                if (l.ContainsKey(c) || c == '-') continue;
                int counter = encryptedName.Count(f => f == c);
                l.Add(c, counter);
            }

            foreach (var item in l.OrderBy(key =>  key.Key))
            {
                Console.WriteLine("{0}, {1}.", item.Key, item.Value);
            }

            Console.WriteLine("\n\n\n");
            int index = 0;

            foreach (char c in checksum)
            {
                if (checksum[index] != l.Keys.ElementAt(index))
                {
                    // Could be due to Keys not sorted alphabetically when values are the same.

                    return false;
                }
                index++;
            }

            return true;
        }

    }
}