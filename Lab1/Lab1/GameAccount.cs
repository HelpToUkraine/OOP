namespace Lab1;

public class GameAccount
{
    private const int InitRating = 10;
    private static readonly List<GameAccount> Accounts = new List<GameAccount>();

    public string UserName { get; }
    public int CurrentRating = InitRating;
    public int GamesCount;

    public readonly List<HistoryGame> HistoryGames;


    public GameAccount(string userName)
    {
        UserName = userName;
        HistoryGames = new List<HistoryGame>();
        Accounts.Add(this);
    }


    public void WinGame(string opponentName, int rating)
    {
        CurrentRating += rating;
        Console.WriteLine($"{UserName} win {opponentName} ---> earned: +{rating} points");
    }


    public void LoseGame(int rating)
    {
        if (CurrentRating - rating < 1)
            CurrentRating = 1;
        else
            CurrentRating -= rating;
    }

    public void GetStats()
    {
        Console.WriteLine($"\nHistory games for '{UserName}':");
        foreach (var game in HistoryGames)
        {

            Console.WriteLine(game);
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
        foreach (var account in Accounts)
        {
            Console.WriteLine(account);
        }
    }
}

