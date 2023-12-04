using System.Collections.Generic;

List<string> lines = new List<string>();
string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 4\input.txt";
if (!File.Exists(filePath))
{
    Console.WriteLine("File not found!");
    return;
}
int i = 1;
using (StreamReader reader = new StreamReader(filePath))
{
    string? line;
    while((line = reader.ReadLine()) != null)
    {
        string temp = line.Replace("Card ", "");
        temp = temp.Replace($"{i}:", "");
        temp = temp.Trim();
        lines.Add(temp);
        i++;
    }
}

int sum = 0;
int count;
foreach(string line in lines)
{
    count = -1;
    String[] row = line.Split("|");
    List<string> winningNumbersStrings = row[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
    List<string> playedNumbersString = row[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
    foreach(string playedNumber in playedNumbersString)
    {
        if(winningNumbersStrings.Contains(playedNumber))
        {
            count++;
        }
    }
    if(count != -1)
    {
        sum += (int)Math.Pow(2, count);
    }
}
Console.WriteLine($"Sum: {sum}");