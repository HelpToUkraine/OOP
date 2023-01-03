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


    public HistoryGame(GameType gameType, int id, string opponent, GameStatus gameStatus, int rating, int currentRating)
    {
        GameType = gameType;
        Id = id;
        Opponent = opponent;
        GameStatus = gameStatus;
        Rating = rating;
        CurrentRating = currentRating;

    }

    public override string ToString()
    {
        return $"{GameType,-10} {Opponent,15} {Id,10} {Rating,15} {GameStatus,10} {CurrentRating,10}";
    }
}