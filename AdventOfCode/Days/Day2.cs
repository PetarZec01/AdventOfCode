using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day2
    {
        public int calculatePoints(int elfPicked, int yourPick)
        {
            int points = 0;
            if (elfPicked == yourPick) points += 3;
            if (elfPicked == (yourPick + 1) % 3) points += 0;
            if (elfPicked == (yourPick + 2) % 3) points += 6;
            points += (yourPick + 1);
            return points;
        }

        public int calculatePointsPart2(int elfPicked, int roundOutcome)
        {
            int points = 0;
            if (roundOutcome == 0) points += (elfPicked+2)%3 + 0 + 1;
            if (roundOutcome == 1) points += elfPicked + 3 + 1;
            if (roundOutcome == 2) points += (elfPicked + 1) % 3 + 6 + 1;
            return points;
        }
        public void Solution()
        {
            Console.WriteLine("Day2");
            LinkedList<string> list = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day2.txt");
            int points1 = 0;
            int points2 = 0;
            foreach (string item in list)
            {
                points1 += calculatePoints(item[0] - 65, item[2] - 88);
                points2 += calculatePointsPart2(item[0] - 65, item[2] - 88);
            }
            Console.WriteLine(points1);
            Console.WriteLine(points2);
        }
    }
}
