using TicTacToe.Enum;
// ReSharper disable MemberCanBePrivate.Global

namespace TicTacToe.Games;

public class HistoryGame
{

    public readonly GameType GameType;
    public readonly int Id;
    public readonly string Opponent;
    public readonly GameStatus GameStatus;
    public readonly int Rating;
    public readonly int CurrentRating;
    public readonly int WinStreakCount;

    public HistoryGame(GameType gameType, int id, string opponent, GameStatus gameStatus, int rating, int currentRating,
        int winStreakCount)
    {
        GameType = gameType;
        Id = id;
        Opponent = opponent;
        GameStatus = gameStatus;
        Rating = rating;
        CurrentRating = currentRating;
        WinStreakCount = winStreakCount;
    }

    public override string ToString()
    {
        return $"{GameType}:\topponent='{Opponent}', gameId={Id}, gameRating={Rating}, " +
               $"result={GameStatus}, rating={CurrentRating}, winStreak={WinStreakCount}";
    }
}