using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Helper
{
    public class ReadFileLineByLine
    {
        public List<string> FileAsStringList(string path)
        {
            return File.ReadLines(path).ToList();
        }

        public string FileAsString(string path)
        {
            return File.ReadAllText(path);
        }
    }
}