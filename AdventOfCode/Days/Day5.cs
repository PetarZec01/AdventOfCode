using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day5
    {

        LinkedList<char>[] toStacks(LinkedList<string> stacksString, int size = 9)
        {
            LinkedList<char>[] stacks = new LinkedList<char>[size];
            int index = 1;
            for (int i = 0; i < size; i++)
            {
                stacks[i] = new LinkedList<char>();
                foreach (var stck in stacksString)
                {
                    if (stck[index] >= 'A' && stck[index] <= 'Z')
                    {
                        stacks[i].AddLast(stck[index]);
                    }
                }
                index += 4;
            }
            return stacks;
        }

        LinkedList<int[]> toInstructions(LinkedList<string> instructionsString)
        {
            LinkedList<int[]> instructions = new LinkedList<int[]>();
            string temp = "";
            int num = 0, counter = 0;
            foreach(var instructionString in instructionsString)
            {
                int[] instruction = new int[3];
                counter = 0;
                foreach(char c in instructionString)
                {
                    if(c>='0' && c <= '9')
                    {
                        temp += c;
                    }
                    else
                    {
                        if (Int32.TryParse(temp, out num))
                        {
                            instruction[counter] = num;
                            counter++;
                        }
                        temp = "";
                    }
                }
                if (Int32.TryParse(temp, out num))
                {
                    instruction[counter] = num;
                    counter++;
                }
                temp = "";
                instructions.AddLast(instruction);
            }
            
            return instructions;
        }

        public void Solution()
        {
            Console.WriteLine("Day 5 (answer is first column):");
            LinkedList<string> strings = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day5.txt");
            LinkedList<string> stacksString = new LinkedList<string>();
            LinkedList <string> instructionsString = new LinkedList<string>();
            LinkedList<string> temp = stacksString;
            foreach(var str in strings)
            {
                if(str!="")temp.AddLast(str);
                else if (str == "") temp = instructionsString;

            }
            LinkedList<char>[] stacks = toStacks(stacksString);
            LinkedList<char>[] stackspt2 = toStacks(stacksString);
            LinkedList<int[]> instuructions = toInstructions(instructionsString);
            char[] chars = new char[0];
            foreach(var ins in instuructions)
            {
                chars = new char[ins[0]];
                for (int i = 0; i < ins[0]; i++)
                {
                    stacks[ins[2]-1].AddFirst(stacks[ins[1]-1].First.Value);
                    chars[i] = stackspt2[ins[1] - 1].First.Value;
                    stackspt2[ins[1] - 1].RemoveFirst();
                    stacks[ins[1]-1].RemoveFirst();
                }
                for (int i = ins[0]-1; i>=0; i--)
                {
                    stackspt2[ins[2] - 1].AddFirst(chars[i]);
                }
            }
            Console.WriteLine("Part one: ");
            foreach(var stck in stacks)
            {
                foreach (char c in stck)
                    Console.Write(c + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Part two: ");
            foreach (var stck in stackspt2)
            {
                foreach (char c in stck)
                    Console.Write(c + " ");
                Console.WriteLine();
            }
        }
    }
}
