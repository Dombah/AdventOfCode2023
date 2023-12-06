using System.Text;
using System.Text.RegularExpressions;

string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 3\input.txt";
if(!File.Exists(filePath))
{
    Console.WriteLine("File not found!");
    return;
}
List<string> lines = new List<string>();
List<char> symbols = new() { '*', '@', '#', '$', '+', '%', '/' , '=', '&', '-'};
using (StreamReader reader = new StreamReader(filePath)){
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
        lines.Add(line);
    }
}

int width = lines[0].Length + 2; // 2 extra empty spaces
int height = lines.Count + 2;
char[,] map = new char[width, height];

for(int i = 0; i < width; i++)
{
    for(int j = 0; j < height; j++)
    {
        if(
            i == 0 || i == height - 1
            ||
            j == 0 || j == width - 1
           )
        {
            map[i,j] = '.'; // Add extra 2 rows and 2 colums of dots
        }
        else
        {
            map[i, j] = lines[i - 1][j - 1];
        }
    }
}
string temp;
bool isGoodDigit;
int sum = 0;
string goodDigits = "";
for (int i = 1; i < width; i++)
{
    goodDigits = "";
    for (int j = 1; j < height; j++)
    {
        temp = "";
        isGoodDigit = false;
        if (map[i,j] == '.')
        {
            continue;
        }
        else if (Char.IsDigit(map[i, j]))
        {
            while (Char.IsDigit(map[i, j]))
            {
                temp += map[i, j];
                char upper = map[i - 1, j]; 
                char lower = map[i + 1, j];
                char left = map[i, j - 1];
                char right = map[i, j + 1];
                char upperLeft = map[i - 1, j - 1];
                char upperRight = map[i - 1, j + 1];
                char lowerLeft = map[i + 1, j - 1];
                char lowerRight = map[i + 1, j + 1];
                if (symbols.Contains(upper) || symbols.Contains(lower) || symbols.Contains(left) || symbols.Contains(right) || symbols.Contains(upperLeft) || symbols.Contains(upperRight) || symbols.Contains(lowerLeft) || symbols.Contains(lowerRight))
                {
                    isGoodDigit = true;
                }
                j++;
            }
            if(isGoodDigit)
            {
                goodDigits += temp + ", ";
                sum += Int32.Parse(temp);
            }
        }
    }
    Console.WriteLine("Line: {0}, digits: {1}", arg0: i, arg1: goodDigits);
}
Console.WriteLine(sum);
