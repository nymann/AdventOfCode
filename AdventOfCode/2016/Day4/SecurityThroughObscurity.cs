using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class SecurityThroughObscurity
    {
        private struct Room
        {
            public string DecryptedName;
            public string EncryptedName;
            public string Checksum;
            public int SectorId;
        }

        private readonly int _idSum = 0; // part 1


        public SecurityThroughObscurity()
        {
            var input = new Helper.ReadFileLineByLine().FileAsStringList("C://Users//Nymann//Documents//day4.txt");
            var listOfRooms = new List<Room>();

            /*string[] input =
            {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "qzmt-zixmtkozy-ivhz-343[zimth]"
            };*/


            foreach (var roomString in input)
            {
                char[] integers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

                var sectorIdIndex = roomString.IndexOfAny(integers);
                var checkSumIndex = roomString.IndexOf('[');

                var room = new Room
                {
                    DecryptedName = roomString.Substring(0, sectorIdIndex).Replace("-", " "), // part 2
                    EncryptedName = roomString.Substring(0, sectorIdIndex).Replace("-", string.Empty),
                    Checksum = roomString.Substring(checkSumIndex + 1, 5),
                    SectorId = Convert.ToInt16(roomString.Substring(sectorIdIndex, checkSumIndex - sectorIdIndex))
                };

                var calculatedChecksum =
                    new string(
                        room.EncryptedName.GroupBy(c => c)
                            .OrderByDescending(g => g.Count())
                            .ThenBy(g => g.Key)
                            .Take(5)
                            .Select(g => g.Key)
                            .ToArray());

                if (!IsRoomReal(calculatedChecksum, room.Checksum)) continue;
                room.DecryptedName = DecryptName(room.DecryptedName, room.SectorId); // part 2
                if (room.DecryptedName.ToLower().Contains("north")) // part 2
                {
                    Console.WriteLine("the corresponding sector id is {0}, to the room with the name: {1}",
                        room.SectorId, room.DecryptedName);
                    break;
                }
                listOfRooms.Add(room);
                _idSum += room.SectorId; // part 1
            }


            Console.ReadKey();
        }


        private static bool IsRoomReal(string calculatedCheckSum, string checksum)
        {
            return calculatedCheckSum.Equals(checksum);
        }


        // part 2.
        private string DecryptName(string room, int sectorId)
        {
            var roomArray = room.ToLower().ToCharArray();
            // 'a'  = 97, 'z' = 122
            for (var i = 0; i < sectorId; i++)
                for (var j = 0; j < roomArray.Length; j++)
                    switch (roomArray[j])
                    {
                        case ' ':
                            break;
                        case 'z':
                            roomArray[j] = 'a';
                            break;
                        default:
                            roomArray[j]++;
                            break;
                    }

            return new string(roomArray);
        }
    }
}