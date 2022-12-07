using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
   
    public class Day6 : IDays
    {
        public int findMarker(string subroutine) 
        {
            bool foundOneRepetition = true;
            for (int i = 0; i < subroutine.Length - 4; i++)
            {
                foundOneRepetition = false;
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (subroutine[j+i] == subroutine[k+i] && j!=k)
                        {
                            foundOneRepetition = true;
                        }
                    }
                }
                if (foundOneRepetition == false) return i + 4;
            }
            return 0;
        }

        public int findMessage(string subroutine)
        {
            bool foundOneRepetition = true;
            for (int i = 0; i < subroutine.Length - 14; i++)
            {
                foundOneRepetition = false;
                for (int j = 0; j < 14; j++)
                {
                    for (int k = 0; k < 14; k++)
                    {
                        if (subroutine[j + i] == subroutine[k + i] && j != k)
                        {
                            foundOneRepetition = true;
                        }
                    }
                }
                if (foundOneRepetition == false) return i + 14;
            }
            return 0;
        }
        public void Solution()
        {
            Console.WriteLine("Day 6:");
            LinkedList<string> list = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day6.txt");

            string subroutine = list.First();
            Console.WriteLine(findMarker(subroutine));
            Console.WriteLine(findMessage(subroutine));

        }
    }
}
