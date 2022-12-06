using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day3
    {
        public void Solution()
        {
            Console.WriteLine("Day3: ");
            LinkedList<string> strings = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day3.txt");
            int points = 0;
            foreach (var line in strings)
            {
                string first = line.Substring(0, line.Length / 2);
                string second = line.Substring((line.Length / 2), (line.Length / 2));
                points += checkLettersScore(first, second);
            }
            Console.WriteLine(points);
            int counter = 0;
            points = 0;
            string[] group = new string[3];
            foreach (var line in strings)
            {
                if(counter == 3)
                {
                    points += groupBadgeScoreBy3(group);
                    counter = 0;
                }
                group[counter++] = line;
            }
            points += groupBadgeScoreBy3(group);
            Console.WriteLine(points);

        }

        private int checkLettersScore(string first, string second)
        {
            int score = 0;

            List<char> lettersInBothStrings = new List<char>();
            foreach (char letter1 in first)
            {
                foreach (var letter2 in second)
                {
                    if(letter1 == letter2 && !lettersInBothStrings.Contains(letter2))
                        lettersInBothStrings.Add(letter1);
                }
            }

            foreach(var letter in lettersInBothStrings)
            {
                if (letter >= 'A' && letter <= 'Z') score += letter - 65 + 27;
                else if (letter >= 'a' && letter <= 'z') score += letter - 96;
            }

            return score;
        }
        private int groupBadgeScoreBy3(string[] group)
        {
            int score = 0;

            foreach(char letter1 in group[0])
            {
                foreach(char letter2 in group[1])
                {
                    if (letter1 == letter2)
                    {
                        foreach (char letter3 in group[2])
                        {
                            if (letter2 == letter3)
                            {
                                if (letter1 >= 'A' && letter1 <= 'Z') score += letter1 - 65 + 27;
                                else if (letter1 >= 'a' && letter1 <= 'z') score += letter1 - 96;
                                return score;
                            }
                        }
                    }
                }
            }

            return score;
        }
    }
}
