using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static List<string> lines;
    static string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 2\input.txt";
    static void Initialize()
    {
        lines = new List<string>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {

                lines.Add(line.Replace(",", ""));
            }
        }
    }
    static void PartOne()
    {
        int r = 12, g = 13, b = 14;
        int r_read = 0, g_read = 0, b_read = 0;
        int id = 1;
        int sum_id = 0;
        String[] subsets;
        int number = 0;
        int spaceTillColor = 2;
        bool faultyID = false; // true if the game can't be possible
        foreach (string line in lines)
        {
            string temp = line.Replace($"Game {id}: ", ""); // remove prefix "Game {id}: "
            subsets = temp.Split("; "); // split into subsets based on the ; delimiter
            foreach (string subset in subsets)
            {
                faultyID = false;
                for (int i = 0; i < subset.Length; i++)
                {
                    r_read = 0;
                    b_read = 0;
                    g_read = 0;
                    if (subset[i] >= '0' && subset[i] <= '9')
                    {
                        if (subset[i + 1] >= '0' && subset[i + 1] <= '9') // if the number has 2 digits
                        {
                            number = 10 * int.Parse(subset[i].ToString()) + int.Parse(subset[i +1].ToString());
                            spaceTillColor = 3;
                        }
                        else // if the number is one digit
                        {
                            number = int.Parse(subset[i].ToString());
                            spaceTillColor = 2;
                        }
                        switch (subset[i + spaceTillColor])
                        {
                            case 'r':
                                r_read = number;
                                break;
                            case 'g':
                                g_read = number;
                                break;
                            case 'b':
                                b_read = number;
                                break;
                        }
                        if (r_read > r || g_read > g || b_read > b)
                        {
                            faultyID = true;
                            break;
                        }
                        i++;
                    }
                }
                if (faultyID)
                    break;
            }
            if (!faultyID)         
                sum_id += id;
            id++;

        }
    Console.WriteLine($"Sum of all valid game IDs: {sum_id}");
    }
    static void PartTwo()
    {
        int r_read = 0, g_read = 0, b_read = 0;
        int id = 1;
        int power_id = 0;
        String[] subsets;
        int number = 0;
        int spaceTillColor = 2;
        foreach (string line in lines)
        {
            r_read = 0;
            b_read = 0;
            g_read = 0;
            string temp = line.Replace($"Game {id}: ", ""); // remove prefix "Game {id}: "
            subsets = temp.Split("; "); // split into subsets based on the ; delimiter
            foreach (string subset in subsets)
            {
                for (int i = 0; i < subset.Length; i++)
                {
                    if (subset[i] >= '0' && subset[i] <= '9')
                    {
                        if (subset[i + 1] >= '0' && subset[i + 1] <= '9') // if the number has 2 digits
                        {
                            number = 10 * int.Parse(subset[i].ToString()) + int.Parse(subset[i + 1].ToString());
                            spaceTillColor = 3;
                        }
                        else // if the number is one digit
                        {
                            number = int.Parse(subset[i].ToString());
                            spaceTillColor = 2;
                        }
                        switch (subset[i + spaceTillColor])
                        {
                            case 'r':
                                r_read = Math.Max(r_read, number);
                                break;
                            case 'g':
                                g_read = Math.Max(g_read, number);
                                break;
                            case 'b':
                                b_read = Math.Max(b_read, number);
                                break;
                        }
                        i++;
                    }
                }
            }
            power_id += r_read * g_read * b_read;
            id++;
        }
        Console.WriteLine($"Power of all valid game IDs: {power_id}");
    }
}

