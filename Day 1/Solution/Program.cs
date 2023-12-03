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
Console.WriteLine(sum);
