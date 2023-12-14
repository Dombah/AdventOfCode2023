using System.Collections;

namespace FunctionsLibrary
{
    public static class Functions
    {
        public static List<string> GetInputLines(string filePath)
        {
            List<string> lines = new List<string>();
            using(StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}