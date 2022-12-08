using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day8 : IDays
    {
        (int[][], int) fromFileReaderToIntMatrix()
        {
            LinkedList<string> inputs = FileReader.ReadFile("C:\\Users\\petar\\Desktop\\advent of code\\AdventOfCode\\inputs\\Day8.txt");
            int size = inputs.First.Value.Length;
            int[][] array = new int[size][];
            int i = 0;
            foreach (var input in inputs)
            {
                array[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    array[i][j] = input[j] - '0';
                }
                i++;
            }
            return (array, size);
        }

        public int visiblePT1(int[][] array, int size)
        {
            int visible = 0;
            bool temp_visible = false;
            for (int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    int current = array[i][j];
                    for (int k = 0; k < j; k++)
                    {
                        if (array[i][j] <= array[i][k])
                            temp_visible = false;
                    }
                    if (temp_visible) { visible++; continue; }
                    temp_visible = true;
                    for (int k = size - 1; k > j; k--)
                    {
                        if (array[i][j] <= array[i][k])
                            temp_visible = false;
                    }
                    if (temp_visible) { visible++; continue; }
                    temp_visible = true;
                    for (int k = 0; k < i; k++)
                    {
                        if (array[i][j] <= array[k][j])
                            temp_visible = false;
                    }
                    if (temp_visible) { visible++; continue; }
                    temp_visible = true;
                    for (int k = size - 1; k > i; k--)
                    {
                        if (array[i][j] <= array[k][j])
                            temp_visible = false;
                    }
                    if (temp_visible) { visible++; continue; }
                    temp_visible = true;
                }
            }
            return visible + size * 4 - 4;
        }

        public int bestTreeScorePT2(int[][] array, int size)
        {
            int up = 0, down = 0, right = 0, left = 0;
            int best_score = 0;
            (int, int, int) best_candidate = new();
            for (int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    up = 0;down = 0;left = 0;right = 0;
                    int current = array[i][j];
                    for (int k = j-1; k >= 0; k--)
                    {
                        if (array[i][j] > array[i][k])
                            left++;
                        else { left++; break; }
                    }
                    for (int k = j+1; k < size; k++)
                    {
                        if (array[i][j] > array[i][k])
                            right++;
                        else { right++; break; }
                    }
                    for (int k = i-1; k >= 0; k--)
                    {
                        if (array[i][j] > array[k][j])
                            up++;
                        else { up++; break; }
                    }
                    for (int k = i+1; k < size; k++)
                    {
                        if (array[i][j] > array[k][j])
                            down++;
                        else { down++; break; }
                    }
                    if ((up * down * left * right) > best_score)
                    {
                        best_score = up * down * left * right;
                        best_candidate = (array[i][j], i, j);
                    }
                }
            }
            Console.WriteLine(best_candidate.Item1 + " " + best_candidate.Item2 + " " + best_candidate.Item3);
            return best_score;
        }

        public void Solution()
        {
            Console.WriteLine("Day 8:");

            (int[][], int) input = fromFileReaderToIntMatrix();
            Console.WriteLine(visiblePT1(input.Item1, input.Item2));
            Console.WriteLine(bestTreeScorePT2(input.Item1, input.Item2));
        }
    }
}