using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class FileReader
    {
        public static LinkedList<string> ReadFile(string path)
        {
            LinkedList<string> lines = new LinkedList<string>();
            using (StreamReader file = new StreamReader(path))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    lines.AddLast(ln);
                }
                file.Close();
            }
            return lines;
        }
    }
}
