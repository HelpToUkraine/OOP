namespace Lab1;

public class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    private  readonly int _rating = 1; /* default value game rating */
    private readonly int _gameId;
    private readonly GameAccount _player;
    private readonly GameAccount _opponent;

    public Game(GameAccount player, GameAccount opponent)
    {
        _player = player;
        _opponent = opponent;
        _gameId = _id++;
        Play();
    }

    public Game(GameAccount player, GameAccount opponent, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Error: 'rating can't have negative value'");
        }
        else if (rating > player.CurrentRating || rating > opponent.CurrentRating)
        {
            throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
        }
        _player = player;
        _opponent = opponent;
        _rating = rating;
        _gameId = _id++;
        Play();
    }

    private void Play()
    {
        Console.Write($"GameId {_gameId}: ");
        var random = new Random();
        if (random.Next(2) < 1)
        {
            _player.WinGame(_opponent.UserName, _rating);
            _player.HistoryGames.Add(new HistoryGame(_gameId, _opponent.UserName, GameStatus.Win, _rating));

            _opponent.LoseGame(_rating);
            _opponent.HistoryGames.Add(new HistoryGame(_gameId, _player.UserName, GameStatus.Lose, _rating));
        }
        else
        {
            _opponent.WinGame(_player.UserName, _rating);
            _opponent.HistoryGames.Add(new HistoryGame(_gameId, _player.UserName, GameStatus.Win, _rating));

            _player.LoseGame(_rating);
            _player.HistoryGames.Add(new HistoryGame(_gameId, _opponent.UserName, GameStatus.Lose, _rating));
        }

        _player.GamesCount++;
        _opponent.GamesCount++;

    }

    public static void CreateGames(GameAccount player1, GameAccount player2, int countGames)
    {
        for (var i = 0; i < countGames; i++)
        {
            new Game(player1, player2);
        }
    }
}