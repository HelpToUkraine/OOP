namespace Lab1;

public class HistoryGame
{
    private readonly int _id;
    private readonly string _opponent;
    private readonly GameStatus _gameStatus;
    private readonly int _rating;

    public HistoryGame(int id, string opponent, GameStatus gameStatus, int rating)
    {
        _id = id;
        _opponent = opponent;
        _gameStatus = gameStatus;
        _rating = rating;
    }

    public override string ToString()
    {
        return $"VS opponent='{_opponent}', gameRating={_rating}, gameId={_id}, Result={_gameStatus}";
    }
}