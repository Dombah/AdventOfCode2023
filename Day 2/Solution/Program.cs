
List<string> lines = new List<string>();
string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 2\input.txt";
if (!File.Exists(filePath))
{
    Console.WriteLine("File not found!");
    return;
}

using (StreamReader sr = new StreamReader(filePath))
{
    string? line;
    while((line = sr.ReadLine()) != null)
    {

        lines.Add(line.Replace(",", ""));
    }
}

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
    foreach(string subset in subsets)
    {
        faultyID = false;
        for(int i = 0; i < subset.Length; i++)
        {
            r_read = 0;
            b_read = 0;
            g_read = 0;
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
                switch(subset[i + spaceTillColor])
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
                if(r_read > r || g_read > g || b_read > b)
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
    {
       sum_id += id;
       Console.WriteLine($"Game {id} is valid");
       id++;
    }
    else
    {
        Console.WriteLine($"Game {id} is invalid");
        id++;
    }

}
Console.WriteLine($"Sum of all valid game IDs: {sum_id}");

