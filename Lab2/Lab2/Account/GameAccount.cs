using Lab2.Games;

namespace Lab2.Account;

public abstract class GameAccount
{
    private const int InitRating = 20;
    private static readonly List<GameAccount> Accounts = new();

    private string UserName { get; }
    private int _currentRating = InitRating;
    private readonly List<HistoryGame> _historyGames;
    protected int WinStreakCount;

    public int CurrentRating
    {
        get => _currentRating;
        private set
        {
            if (_currentRating - value < 1)
            {
                _currentRating = 1;
            }
            else
            {
                _currentRating -= value;
            }
        }
    }

    protected GameAccount(string userName)
    {
        UserName = userName;
        _historyGames = new List<HistoryGame>();
        Accounts.Add(this);
    }

    public void WinGame(Game game)
    {
        if (game.GetType() != typeof(TrainingGame))
            WinStreakCount++;
        var rating = GetBonus(game.GetRating);
        _currentRating += rating;
        _historyGames.Add(new HistoryGame(Game.GetObjectType(game), game.GameId, GetOpponentName(game),
            GameStatus.Win, rating, _currentRating, WinStreakCount));
    }

    public void LoseGame(Game game)
    {
        if (game.GetType() != typeof(TrainingGame))
            WinStreakCount = 0;
        var rating = GetBonus(game.GetRating);

        CurrentRating = rating;
        _historyGames.Add(new HistoryGame(Game.GetObjectType(game), game.GameId, GetOpponentName(game),
            GameStatus.Lose, rating, _currentRating, WinStreakCount));
    }

    public void GetStats()
    {
        Console.WriteLine($"\nHistory games for '{UserName}':");
        foreach (var game in _historyGames)
        {
            Console.WriteLine(game);
        }
    }

    public override string ToString()
    {
        return '{'
               + "userName='" + UserName + '\''
               + ",\ttype='" + Game.GetObjectType(this) + '\''
               + ",\tcurrentRating=" + _currentRating
               + ",\tgamesCount=" + _historyGames.Count
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

    private string GetOpponentName(Game game)
    {
        if (game.GetType() == typeof(SingleGame)) return "BOT";
        return Equals(game.Player) ? game.Opponent.UserName : game.Player.UserName;
    }

    protected abstract int GetBonus(int rating);
}