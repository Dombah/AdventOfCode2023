using System.Data.Common;
using System.Diagnostics.Tracing;

string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 1\input.txt";
if(!File.Exists(filePath))
{
    Console.WriteLine("File not found");
    return;
}
List<string> lines = new List<string>();
using(StreamReader sr = new StreamReader(filePath))
{
    string? line;
    while((line = sr.ReadLine()) != null)
    {
        lines.Add(line);
    }
    sr.Close();
}
/* Part 1
int firstDigit = 0, lastDigit = 0;
int sum = 0;
foreach(string line in lines)
{
    foreach(char c in line)
    {
        if(firstDigit == 0 && (c >= '0' && c <= '9'))
        {
            firstDigit = int.Parse(c.ToString());
            lastDigit = firstDigit;
        }
        else if(firstDigit != 0 && (c >= '0' && c <= '9'))
        {
            lastDigit = int.Parse(c.ToString());
        }
    }
    sum += firstDigit * 10 + lastDigit;
    firstDigit = 0; 
    lastDigit = 0;
}
Console.WriteLine(sum);*/

Dictionary<string, int> wordToInt = new Dictionary<string, int>
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};

string currentWord;
int firstDigit, lastDigit;
int sum = 0;
foreach (string line in lines)
{
    firstDigit = 0;
    lastDigit = 0;
    currentWord = "";
    for (int i = 0; i < line.Length; i++)
    {
        if (Char.IsDigit(line[i]))
        {
            int parsedValue = int.Parse(line[i].ToString());
            if(firstDigit == 0)
            {
                firstDigit = parsedValue;
            }
            lastDigit = parsedValue;
        }
        else
        {
            currentWord = "";
            for(int j = i; j < line.Length; j++)
            {
                currentWord += line[j];
                if(wordToInt.ContainsKey(currentWord))
                {
                    int value = wordToInt[currentWord];
                    if(firstDigit == 0)
                    {
                        firstDigit = value;
                    }
                    lastDigit = value;
                    break;
                }
            }
        }
    }
    sum += firstDigit * 10 + lastDigit;
    Console.WriteLine(firstDigit + " " + lastDigit);
}
Console.WriteLine(sum);
