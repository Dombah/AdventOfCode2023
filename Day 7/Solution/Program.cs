var lines = File.ReadAllLines(@"C:\Users\Domagoj\source\repos\AdventOfCode2023\Day 7\input.txt");
var hands = new List<Hand>();
foreach(var line in lines)
{
    var parts = line.Split(' ');
    var hand = new Hand(parts[0], int.Parse(parts[1]));
    hands.Add(hand);
}
hands.Sort();

var totalWinings = 0;
for (int i = 0; i < hands.Count; i++)
{
    totalWinings += hands[i].Bid * (i + 1);
}
Console.WriteLine(totalWinings);

class Hand: IComparable<Hand>
{
    char[] CardRanks = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

    private readonly string cards;
    private readonly int bid;

    private Dictionary<char, int> cardCounts = new();

    public int Bid => bid;

    public Hand(string cards, int bid)
    {
        this.cards = cards;
        this.bid = bid;
        foreach(char rank in CardRanks)
        {
            cardCounts.Add(rank, 0);
        }
        for(int i = 0; i < cards.Length; i++)
        {
            cardCounts[cards[i]]++;
        }
    }
    public int GetStrength()
    {
        if(cardCounts.Any(c => c.Value == 5))
        {
            return 7;
        }
        if (cardCounts.Any(c => c.Value == 4))
        {
            return 6;
        }
        if (cardCounts.Any(c => c.Value == 3) && cardCounts.Any(c => c.Value == 2))
        {
            return 5;
        }
        if (cardCounts.Any(c => c.Value == 3))
        {
            return 4;
        }
        if (cardCounts.Count(c => c.Value == 2) == 2)
        {
            return 3;
        }
        if (cardCounts.Any(c => c.Value == 2))
        {
            return 2;
        }
        return 1;
    }

    public int CompareTo(Hand? other)
    {
        if(other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }
        var strengthComp = GetStrength().CompareTo(other.GetStrength());
        if(strengthComp != 0)
        {
            return strengthComp;
        }
        else
        {
            for(int i = 0; i < cards.Length; i++)
            {
                var cardComp = Array.IndexOf(CardRanks, other.cards[i]).
                    CompareTo(Array.IndexOf(CardRanks, cards[i]));
                if(cardComp != 0)
                {
                    return cardComp;
                }
            }
        }
        return 0;
    }
}