namespace Lab2.Games;

public class HistoryGame
{
    private readonly string _gameType;
    private readonly int _id;
    private readonly string _opponent;
    private readonly GameStatus _gameStatus;
    private readonly int _rating;
    private readonly int _currentRating;
    private readonly int _winStreakCount;

    public HistoryGame(string gameType, int id, string opponent, GameStatus gameStatus, int rating, int currentRating,
        int winStreakCount)
    {
        _gameType = gameType;
        _id = id;
        _opponent = opponent;
        _gameStatus = gameStatus;
        _rating = rating;
        _currentRating = currentRating;
        _winStreakCount = winStreakCount;
    }

    public override string ToString()
    {
        return $"{_gameType}\tVS\topponent='{_opponent}', gameId={_id}, gameRating={_rating}, " +
               $"result={_gameStatus}, rating={_currentRating}, winStreak={_winStreakCount}";
    }
}