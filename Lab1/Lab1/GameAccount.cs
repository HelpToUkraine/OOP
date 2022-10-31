namespace Lab1;

public class GameAccount
{
    private const int InitRating = 10;
    private static readonly List<GameAccount> Accounts = new();

    private readonly string _userName;
    private readonly List<HistoryGame> _historyGames;
    public int CurrentRating = InitRating;

    public GameAccount(string userName)
    {
        _userName = userName;
        _historyGames = new List<HistoryGame>();
        Accounts.Add(this);
    }

    public void WinGame(Game game)
    {
        var opponentName = GetOpponentName(game);
        var rating = game.Rating;

        CurrentRating += rating;
        _historyGames.Add(new HistoryGame(game.GameId, opponentName, GameStatus.Win, rating));
        Console.WriteLine($"{_userName} win {opponentName} ---> earned: +{rating} points");
    }

    public void LoseGame(Game game)
    {
        var opponentName = GetOpponentName(game);
        var rating = game.Rating;
        if (CurrentRating - rating < 1)
            CurrentRating = 1;
        else
            CurrentRating -= rating;
        _historyGames.Add(new HistoryGame(game.GameId, opponentName, GameStatus.Lose, rating));
    }

    public void GetStats()
    {
        Console.WriteLine($"\nHistory games for '{_userName}':");
        foreach (var game in _historyGames)
        {
            Console.WriteLine(game);
        }
    }

    public override string ToString()
    {
        return "GameAccount{"
               + "userName='" + _userName + '\''
               + ", currentRating=" + CurrentRating
               + ", gamesCount=" + _historyGames.Count
               + '}';
    }

    private string GetOpponentName(Game game)
    {
        return Equals(game.Player) ? game.Opponent._userName : game.Player._userName;
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