string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 6\input.txt";
if (!File.Exists(filePath))
{
    Console.WriteLine("File not found!");
    return;
}
List<string> lines = new List<string>();
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
/*
Time:        53     71     78     80
Distance:   275   1181   1215   1524
*/
int[] times = new int[lines.Count / 2];
int[] distances = new int[lines.Count / 2];
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

for(int i = 0; i < 4; i++)
{
    Console.WriteLine($"Time: {times[i]}, Record: {distances[i]}");
}

long totalMultiplication = 1;
int numberOfWays = 0;
for(int i = 0; i < times.Length; i++)
{
    numberOfWays = 0;
    int distanceToBeat = distances[i];
    Console.WriteLine("Run: {0}", arg0: i + 1);
    for(int j = 1; j < times[i]; j++)
    {
        if(distanceToBeat < (times[i] - j)* j)
        {
            numberOfWays++;
            Console.WriteLine("Beaten at index: " + j);
        }
    }
    totalMultiplication *= numberOfWays;
}
Console.WriteLine(totalMultiplication);


