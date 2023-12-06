using System.Numerics;

partial class Program 
{
    static string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 6\input.txt";
    static int[]? times;
    static int[]? distances;
    static List<string> lines = new List<string>();
    public static void ReadInput()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Replace("Time: ", "").Replace("Distance: ", "");
                line = line.Trim();
                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in parts)
                {
                    lines.Add(item);
                }

            }
        }
        times = new int[lines.Count / 2];
        distances = new int[lines.Count / 2];
        for (int i = 0; i < lines.Count; i++)
        {
            if (i < lines.Count / 2)
            {
                times[i] = int.Parse(lines[i]);
            }
            else
            {
                distances[i - lines.Count / 2] = int.Parse(lines[i]);
            }
        }
    }
    public static void PartOne()
    {
        long totalMultiplication = 1;
        int numberOfWays;
        for (int i = 0; i < times.Length; i++)
        {
            numberOfWays = 0;
            int distanceToBeat = distances[i];
            for (int j = 1; j < times[i]; j++)
            {
                if (distanceToBeat < (times[i] - j) * j)
                {
                    numberOfWays++;
                }
            }
            totalMultiplication *= numberOfWays;
        }
        Console.WriteLine(totalMultiplication);
    }
    public static void PartTwo()
    {
        string temp = "";
        int time = 0;
        BigInteger distance = 0;
        foreach (int number in times)
        {
            temp += number.ToString();  
        }
        time = int.Parse(temp);
        temp = "";
        foreach (int number in distances)
        {
            temp += number.ToString();
        }
        distance = long.Parse(temp);
        int numberOfWays = 0;
        for (int i = 1; i < time; i++)
        {
            long current = (long)(time - i) * i;
            if (distance < current)
            {
                numberOfWays++;
            }
        }
        Console.WriteLine(numberOfWays);
    }
}