using FunctionsLibrary;
partial class Program
{
    static string filePath = @"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 7\input.txt";
    static Dictionary<string, int> linesValuesDict = new Dictionary<string, int>();
    static List<char> cards = new List<char>() { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J','Q','K','A' }; 
    public static void ReadFile()
    {
        List<string> rawLines = Functions.GetInputLines(filePath);
        foreach(string line in rawLines)
        {
            string[] splitLine = line.Split(' ');
            string val = splitLine[0];
            linesValuesDict.Add(val, int.Parse(splitLine[1]));
        }
    }
    public static void PartOne()
    {
        Dictionary<string, int> fiveKind = new Dictionary<string, int>();         
        Dictionary<string, int> fourKind = new Dictionary<string, int>();               
        Dictionary<string, int> fullHouse = new Dictionary<string, int>();               
        Dictionary<string, int> threeKind = new Dictionary<string, int>();               
        Dictionary<string, int> twoPair = new Dictionary<string, int>();
        Dictionary<string, int> onePair = new Dictionary<string, int>();
        Dictionary<string, int> highCard = new Dictionary<string, int>();

        List<int> counts = new List<int>();
        int count;
        int oldCount;
        int replacedCount;
        foreach (var item in linesValuesDict)
        {
            counts.Clear();
            count = 0;
            oldCount = 0;
            replacedCount = 0;
            string key = item.Key;
            char[] keyChars = key.ToCharArray();
            Array.Sort(keyChars);
            string sortedKey = new string(keyChars);
            foreach (char c in cards)
            {
                if (sortedKey == "")
                    break;
                if(sortedKey.Contains(c))
                {
                    oldCount = sortedKey.Length;
                    sortedKey = sortedKey.Replace(c.ToString(), "");
                    replacedCount = oldCount - sortedKey.Length;
                    counts.Add(replacedCount);
                    count++;
                }
            }
            if(count == 1)
            {
                fiveKind.Add(key, item.Value);
            }
            else if(count == 2)
            {
                foreach (int c in counts)
                {
                    if(c == 1)
                    {
                        fourKind.Add(key, item.Value);
                        break;
                    }
                    else if(c == 2)
                    {
                        fullHouse.Add(key, item.Value);
                        break;
                    }
                }
            }
            else if(count == 3)
            {
                foreach (int c in counts)
                {
                    
                    if (c == 3)
                    {
                        threeKind.Add(key, item.Value);
                        break;
                    }
                    else if (c == 2)
                    {
                        twoPair.Add(key, item.Value);
                        break;
                    }
                }
            }
            else if(count == 4)
            {
                onePair.Add(key, item.Value);
            }
            else if(count == 5)
            {
                highCard.Add(key, item.Value);
            }
        }
        var sortedDictionary = fourKind.OrderBy(entry => entry.Key, new FirstLetterComparer());
        foreach (var item in sortedDictionary)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

    }

}