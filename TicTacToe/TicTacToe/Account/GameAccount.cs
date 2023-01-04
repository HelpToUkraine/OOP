using System.Runtime.Serialization;
using Newtonsoft.Json;
using TicTacToe.Enum;
using TicTacToe.Games;
using TicTacToe.Services;

namespace TicTacToe.Account;

[JsonObject, DataContract]
public abstract class GameAccount
{
    private const int InitRating = 20;

    [DataMember] private int _currentRating = InitRating;

    public readonly string UserName;
    public readonly AccountType Type;
    public readonly List<HistoryGame> HistoryGames;

    public int CurrentRating
    {
        get => _currentRating;
        private set
        {
            if (_currentRating + value < 1)
            {
                _currentRating = 1;
            }
            else
            {
                _currentRating += value;
            }
        }
    }

    protected GameAccount(string userName, AccountType type)
    {
        if (UserService.IsUserExist(userName))
            throw new ArgumentException("An account with same name already exists");
        UserName = userName;
        Type = type;
        HistoryGames = new List<HistoryGame>();
        UserService.Add(this);
    }


    // constructor for serialize | deserialize
    protected GameAccount(string userName, AccountType type, List<HistoryGame> historyGames)
    {
        UserName = userName;
        Type = type;
        HistoryGames = historyGames;
    }

    public void WinGame(Game game)
    {
        var rating = GetBonus(game.GetRating);
        CurrentRating = rating;
        HistoryGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game), GameStatus.Win, rating,
            _currentRating));
    }

    public void LoseGame(Game game)
    {
        var rating = GetBonus(game.GetRating);

        CurrentRating = -rating;
        HistoryGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Lose, rating, _currentRating));
    }

    public void DrawGame(Game game)
    {
        HistoryGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Draw, game.GetRating, _currentRating));
    }

    public static void GetGamesInfo()
    {
        if (UserService.Get().Count == 0)
        {
            Console.WriteLine("\nNo games yet");
            return;
        }

        Console.WriteLine($"\nHistory games for:");
        Console.WriteLine("{0, -10} {1, -10} {2, 15} {3, 10} {4, 15} {5, 10} {6, 10}", "Name", "Type", "Opponent",
            "GameId", "GameRating", "Result", "Rating");
        Console.ResetColor();
        foreach (var account in UserService.Get())
        {
            foreach (var game in account.HistoryGames)
            {
                Console.WriteLine("{0, -10} {1}", account.UserName, game);
            }
        }
    }

    public override string ToString()
    {
        return $"{UserName,-10} {Type,10} {_currentRating,10} {HistoryGames.Count,10}";
    }

    public static void GetAccountsInfo()
    {
        Console.WriteLine("\nStatistics players:");
        Console.WriteLine("{0, -10} {1, 10} {2, 10} {3, 10}", "Name", "Type", "Rating", "Games");
        Console.ResetColor();
        UserService.Get().ForEach(Console.WriteLine);
    }

    protected int GetWinStreakCount()
    {
        var winStreakCount = 0;
        for (var i = HistoryGames.Count - 1; i >= 0; i--)
        {
            if (HistoryGames[i].GameType == GameType.Training)
                continue;
            if (HistoryGames[i].GameStatus == GameStatus.Win)
                winStreakCount++;
            else
                break;
        }

        return winStreakCount;
    }

    private string GetOpponentName(Game game)
    {
        if (game.Type == GameType.Single) return "BOT";
        return Equals(game.Player) ? game.Opponent.UserName : game.Player.UserName;
    }

    protected abstract int GetBonus(int rating);
}