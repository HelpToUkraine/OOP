using Lab2.Games;

namespace Lab2.Account;

public abstract class GameAccount
{
    private const int InitRating = 10;
    private static readonly List<GameAccount> Accounts = new List<GameAccount>();

    public string UserName { get; }
    public int CurrentRating = InitRating;
    public int GamesCount;
    protected int WinStreakCount;

    public readonly List<HistoryGame> HistoryGames;


    protected GameAccount(string userName)
    {
        UserName = userName;
        HistoryGames = new List<HistoryGame>();
        Accounts.Add(this);
    }


    public void WinGame(Game currentGame) // int rating
    {
        var rating = GetBonus(currentGame.Rating);
        WinStreakCount++;
        CurrentRating += rating; /* GetBonus(rating); wrapper currentGame*/

        // TODO: delete
        // Console.WriteLine($"{UserName} win {opponentName} ---> earned: +{rating} points");
    }


    public void LoseGame(Game currentGame)
    {
        var rating = GetBonus(currentGame.Rating);  /*currentGame.GetRating(this);*/
        WinStreakCount = 0;
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

    public abstract int GetBonus(int rating);
}

