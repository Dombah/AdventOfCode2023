public class FirstLetterComparer : IComparer<string>
{
    private readonly string orderChars = "123456789TJQKA";

    public int Compare(string x, string y)
    {
        char firstLetterX = x.First();
        char firstLetterY = y.First();

        switch (firstLetterX)
        {
            case 'T':
                firstLetterX = 'A';
                break;
            case 'J':
                firstLetterX = 'B';
                break;
            case 'Q':
                firstLetterX = 'C';
                break;
            case 'K':
                firstLetterX = 'D';
                break; 
            case 'A':
                firstLetterX = 'E';
                break;
        }
        switch(firstLetterY)
        {
            case 'T':
                firstLetterY = 'A';
                break;
            case 'J':
                firstLetterY = 'B';
                break;
            case 'Q':
                firstLetterY = 'C';
                break;
            case 'K':
                firstLetterY = 'D';
                break;
            case 'A':
                firstLetterY = 'E';
                break;
        }

        int indexX = orderChars.IndexOf(firstLetterX);
        int indexY = orderChars.IndexOf(firstLetterY);

        return indexY.CompareTo(indexX); // Compare in descending order
    }
}