using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Day4
{
    internal class Program
    {
        public static LinkedList<string> ReadFile()
        {
            LinkedList<string> lines = new LinkedList<string>();
            string textFile = "C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\Day4\\Day4\\advent_of_code4.txt";
            using (StreamReader file = new StreamReader(textFile))
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

        public static int[] numberRecognition(string line)
        {
            int[] numbers = new int[4];
            string temp = "";
            int number = 0;
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if(line[i] >= '0' && line[i] <= '9')
                {
                    temp+=line[i];
                }
                else
                {
                    
                    if (Int32.TryParse(temp, out number))
                    {
                        numbers[counter] = number;
                        counter++;
                    }
                    temp = "";
                }
            }
            int num = 0;
            if (Int32.TryParse(temp, out num))
            {
                numbers[counter] = num;
            }
            return numbers;
        }

        static void Main(string[] args)
        {
            LinkedList<string> lines = ReadFile();
            int contains = 0;
            foreach (var line in lines)
            {
                int[] numbers = numberRecognition(line);
                
                if (numbers[0] >= numbers[2] && numbers[1] <= numbers[3])
                    contains++;
                else if (numbers[2] >= numbers[0] && numbers[3] <= numbers[1])
                    contains++;
            }


            Console.WriteLine(contains);
            Console.ReadLine();
        }
    }
}
