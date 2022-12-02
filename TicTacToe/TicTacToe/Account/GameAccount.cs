using TicTacToe.Enum;
using TicTacToe.Games;
using TicTacToe.Services;

namespace TicTacToe.Account;

public abstract class GameAccount
{
    private const int InitRating = 20;

    public readonly string UserName;
    private readonly AccountType _type;
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

    protected GameAccount(string userName, AccountType type)
    {
        UserName = userName;
        _type = type;
        _historyGames = new List<HistoryGame>();
        UserService.Add(this);
    }

    public void WinGame(Game game)
    {
        if (game.GetType() != typeof(TrainingGame))
            WinStreakCount++;
        var rating = GetBonus(game.GetRating);

        _currentRating += rating;
        _historyGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Win, rating, _currentRating, WinStreakCount));
    }

    public void LoseGame(Game game)
    {
        if (game.GetType() != typeof(TrainingGame))
            WinStreakCount = 0;
        var rating = GetBonus(game.GetRating);

        CurrentRating = rating;
        _historyGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Lose, rating, _currentRating, WinStreakCount));
    }

    public void DrawGame(Game game)
    {
        _historyGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Draw, game.GetRating, _currentRating, WinStreakCount));
    }

    public static void GetGamesInfo()
    {
        foreach (var account in UserService.Get())
        {
            Console.WriteLine($"\nHistory games for '{account.UserName}':");
            foreach (var game in account._historyGames)
            {
                Console.WriteLine(game);
            }
        }
    }

    public override string ToString()
    {
        return '{'
               + "userName='" + UserName + '\''
               + ",\ttype='" + _type + '\''
               + ",\tcurrentRating=" + _currentRating
               + ", gamesCount=" + _historyGames.Count
               + '}';
    }

    public static void GetAccountsInfo()
    {
        Console.WriteLine("\nStatistics players:");
        foreach (var account in UserService.Get())
        {
            Console.WriteLine(account);
        }
    }

    private string GetOpponentName(Game game)
    {
        if (game.Type == GameType.SingleGame) return "BOT";
        return Equals(game.Player) ? game.Opponent.UserName : game.Player.UserName;
    }

    protected abstract int GetBonus(int rating);
}