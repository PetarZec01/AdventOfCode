using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class File
    {
        public string Name { get; set; }
        public long  Size { get; set; }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }   
    }
    public class Directory
    {
        public Directory Parent = null;
        public string Name { get; set; }
        public int Size = 0;
        public List<Directory> Directories = new List<Directory>();
        public List<File> Files = new List<File>();

        public Directory(string name)
        {
            Name = name;
        }

        public int getSize() { return Size; }
    }

    

    public class Day7 : IDays
    {
        public Directory setupTree(LinkedList<string> list)
        {
            LinkedList<string[]> listSplit = new();
            foreach (var item in list)
            {
                listSplit.AddLast(item.Split(" "));
            }

            int num1 = 0;
            int sum = 0;
            foreach(var item in listSplit)
            {
                if (Int32.TryParse(item[0], out num1))
                {
                    sum += num1;
                }
            }
            Console.WriteLine(sum);

            Directory currentDir = new Directory("/");
            bool first = true;
            bool isLs = false;
            foreach (var item in listSplit)
            {
                if (first) { first = false; continue; }
                if (item[0] == "$" && item[1] == "cd") isLs = false;

                if (!isLs)
                {
                    if (item[1] == "cd" && item[2] != "..")
                    {
                        foreach (var dir in currentDir.Directories)
                        {
                            Directory temp = currentDir;
                            if (dir.Name == item[2])
                            {
                                currentDir = dir;
                                dir.Parent = temp;
                            }
                        }

                    }

                    if (item[0] == "$" && item[1] == "ls")
                    {
                        isLs = true;
                    }

                    if (item[1] == "cd" && item[2] == "..")
                        currentDir = currentDir.Parent;

                }
                else
                {
                    int number = 0;
                    if (item[0] == "dir")
                    {
                        bool exists = false;
                        foreach (var dir in currentDir.Directories)
                            if (item[1] == dir.Name) exists = true;

                        if (!exists)
                            currentDir.Directories.Add(new Directory(item[1]));
                    }
                    else if (Int32.TryParse(item[0], out number))
                    {
                        bool exists = false;
                        foreach (var file in currentDir.Files)
                            if (item[1] == file.Name) exists = true;

                        if (!exists)
                        {
                            currentDir.Files.Add(new File(item[1], number));
                            Directory temp = currentDir;
                            while(temp!=null)
                            {
                                temp.Size += number;
                                temp = temp.Parent;
                            }
                        }
                            
                    }
                }
            }

            while (currentDir.Parent != null)
                currentDir = currentDir.Parent;

            return currentDir;
        }

        List<Directory> candidatesPT1 = new List<Directory>();
        public void findCandidatesPT1(Directory search)
        {
            if(search.Size<=100000) candidatesPT1.Add(search);

            if (search.Directories.Count == 0) return;
            else if (search.Directories.Count != 0)
            {
                foreach(var dir in search.Directories)
                {
                    findCandidatesPT1(dir);
                }
            }
        }

        Directory bestCandidate = null;
        public void findCandidatesPT2(Directory search, int size)
        {
            if (bestCandidate==null || (search.Size >=size && search.Size<bestCandidate.Size))
                bestCandidate = search;

            if (search.Directories.Count == 0) return;
            else if (search.Directories.Count != 0)
            {
                foreach (var dir in search.Directories)
                {
                    findCandidatesPT2(dir, size);
                }
            }
        }

        public void Solution()
        {
            Console.WriteLine("Day 7: ");
            LinkedList<string> list = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day7.txt");
            
            Directory mainDir = setupTree(list);
            Console.WriteLine(mainDir.Size);
            findCandidatesPT1(mainDir);
            int result = 0;
            foreach (var candidate in candidatesPT1)
            {
                result+=candidate.Size;
            }
            Console.WriteLine(result);

            findCandidatesPT2(mainDir, Math.Abs(70000000 - mainDir.Size - 30000000));
            Console.WriteLine(bestCandidate.Size);

        }
    }
}
