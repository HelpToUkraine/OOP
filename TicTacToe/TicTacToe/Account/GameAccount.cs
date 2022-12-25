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
            if (_currentRating - value < 1)
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
            _currentRating, game.Type != GameType.TrainingGame
                ? GetWinStreakCount() + 1
                : GetWinStreakCount()));
    }

    public void LoseGame(Game game)
    {
        var rating = GetBonus(game.GetRating);

        CurrentRating = -rating;
        HistoryGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Lose, rating, _currentRating, 0));
    }

    public void DrawGame(Game game)
    {
        HistoryGames.Add(new HistoryGame(game.Type, game.GameId, GetOpponentName(game),
            GameStatus.Draw, game.GetRating, _currentRating, GetWinStreakCount()));
    }

    public static void GetGamesInfo()
    {
        if (UserService.Get().Count == 0)
        {
            Console.WriteLine("\nNo games yet");
            return;
        }
        foreach (var account in UserService.Get())
        {
            Console.WriteLine($"\nHistory games for '{account.UserName}':");
            foreach (var game in account.HistoryGames)
            {
                Console.WriteLine(game);
            }
        }
    }

    public override string ToString()
    {
        return '{'
               + "userName='" + UserName + '\''
               + ",\ttype='" + Type + '\''
               + ",\tcurrentRating=" + _currentRating
               + ", gamesCount=" + HistoryGames.Count
               + '}';
    }

    public static void GetAccountsInfo()
    {
        Console.WriteLine("\nStatistics players:");
        UserService.Get().ForEach(Console.WriteLine);
    }

    protected int GetWinStreakCount()
    {
        var winStreakCount = 0;
        for (var i = HistoryGames.Count - 1; i >= 0; i--)
        {
            if (HistoryGames[i].GameType == GameType.TrainingGame)
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
        if (game.Type == GameType.SingleGame) return "BOT";
        return Equals(game.Player) ? game.Opponent.UserName : game.Player.UserName;
    }

    protected abstract int GetBonus(int rating);
}