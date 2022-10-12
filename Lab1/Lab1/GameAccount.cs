namespace Lab1;

public class GameAccount
{
    private const int InitRating = 10;
    private static List<GameAccount> _accounts = new List<GameAccount>();

    public string UserName { get; }
    public int CurrentRating = InitRating;
    public int GamesCount;
    public List<Game> HistoryGames;


    public GameAccount(string userName)
    {
        UserName = userName;
        HistoryGames = new List<Game>();
        _accounts.Add(this);
    }


    public void WinGame(string opponentName, int rating)
    {
        CurrentRating += rating;
        Console.WriteLine($"{UserName} win {opponentName} ---> earned: +{rating} points");
    }


    public void LoseGame(string opponentName, int rating)
    {
        if (CurrentRating - rating < 1)
            CurrentRating = 1;
        else
            CurrentRating -= rating;
    }

    public void GetStats()
    {
        Console.WriteLine($"\nHistory games for '{this.UserName}':");
        foreach (var game in HistoryGames)
        {
            Console.WriteLine(game.ToString());
        }
    }

    public override string ToString()
    {
        return "GameAccount{"
               + "userName='"+ UserName + '\''
               + ", currentRating=" + CurrentRating
               + ", gamesCount=" + GamesCount
               + '}';
    }

    public static void GetAccountsInfo()
    {
        Console.WriteLine("\nStatistics players:");
        foreach (var account in _accounts)
        {
            Console.WriteLine($"{account}");
        }
    }
}

