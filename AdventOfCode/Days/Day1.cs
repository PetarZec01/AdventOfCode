using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day1 : IDays
    {
        public void Solution()
        {
            Console.WriteLine("Day 1:");
            LinkedList<string> numbersString = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day1.txt");
            LinkedList<int> numbers = new LinkedList<int>();
            int max = 0, temp = 0;
            
            foreach(string numberString in numbersString)
            {
                if (numberString == "")
                {
                    numbers.AddLast(temp);
                    if (temp > max) max = temp;
                    temp = 0;
                    continue;
                }
                temp += Int32.Parse(numberString);
            }
            Console.WriteLine(max);

            temp = 0;
            for (int i = 0; i < 3; i++)
            {
                temp += numbers.Max();
                numbers.Remove(numbers.Max());
            }
            Console.WriteLine(temp);

        }
    }
}
